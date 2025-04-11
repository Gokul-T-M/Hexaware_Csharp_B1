using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using DigitalAssetManagentSystem.exceptions;
using DigitalAssetManagentSystem.model;
using DigitalAssetManagentSystem.util;
using Microsoft.Data.SqlClient;

namespace DigitalAssetManagentSystem.dao
{
    public class AssetManagementServiceImpl : IAssetManagementService
    {
        private readonly SqlConnection con;

        public AssetManagementServiceImpl()
        {
            con = DBConnUtil.GetConnection("appsettings.json");
            
        }

        public bool AddAsset(Asset asset)
        {
            try
            {
                
                string query = "insert into tblAssets (asset_name, asset_type, serial_number, purchase_date, asset_location, asset_status, owner_id) " +
                               "values (@asset_name, @asset_type, @serial_number, @purchase_date, @asset_location, @asset_status, @owner_id)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@asset_name", asset.AssetName);
                cmd.Parameters.AddWithValue("@asset_type", asset.AssetType);
                cmd.Parameters.AddWithValue("@serial_number", asset.SerialNumber);
                cmd.Parameters.AddWithValue("@purchase_date", asset.PurchaseDate);
                cmd.Parameters.AddWithValue("@asset_location", asset.AssetLocation);
                cmd.Parameters.AddWithValue("@asset_status", asset.AssetStatus);
                cmd.Parameters.AddWithValue("@owner_id", asset.OwnerId);

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                con.Close();

                return rows > 0;
            }
            catch (SqlException e)
            {
                Console.WriteLine("SQL Error (AddAsset): " + e.Message);
                return false;
            }
        }


        public bool UpdateAsset(Asset asset)
        {
            try
            {
                string query = "update tblAssets set asset_name=@asset_name, asset_type=@asset_type, serial_number=@serial_number, purchase_date=@purchase_date, " +
                               "asset_location=@asset_location, asset_status=@asset_status, owner_id=@owner_id where asset_id=@asset_id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@asset_id", asset.AssetId);
                cmd.Parameters.AddWithValue("@asset_name", asset.AssetName);
                cmd.Parameters.AddWithValue("@asset_type", asset.AssetType);
                cmd.Parameters.AddWithValue("@serial_number", asset.SerialNumber);
                cmd.Parameters.AddWithValue("@purchase_date", asset.PurchaseDate);
                cmd.Parameters.AddWithValue("@asset_location", asset.AssetLocation);
                cmd.Parameters.AddWithValue("@asset_status", asset.AssetStatus);
                cmd.Parameters.AddWithValue("@owner_id", asset.OwnerId);

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                con.Close();

                if (rows == 0)
                    throw new AssetNotFoundException($"Asset with Asset ID {asset.AssetId} not found! ");

                return true;
            }
            catch (AssetNotFoundException ae)
            {
                Console.WriteLine("Please enter a valid AssetId: " + ae.Message);
                return false;
            }
            catch (SqlException e)
            {
                Console.WriteLine("SQL Error (UpdateAsset): " + e.Message);
                return false;
            }
        }


        public bool DeleteAsset(int assetId)
        {
            try
            {
                string query = "delete from tblAssets where asset_id=@asset_id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@asset_id", assetId);

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                con.Close();

                if (rows == 0)
                    throw new AssetNotFoundException("Asset not found for deletion.");

                return true;
            }
            catch (SqlException e)
            {
                Console.WriteLine("SQL Error (DeleteAsset): " + e.Message);
                return false;
            }
        }


        public bool AllocateAsset(int assetId, int employeeId, string allocationDate)
        {
            try
            {
                con.Open();

                DateTime allocation = Convert.ToDateTime(allocationDate);

                // check already allocated and not returned
                string query1 = "select count(*) from tblAssetAllocations where asset_id = @asset_id and return_date is null";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                cmd1.Parameters.AddWithValue("@asset_id", assetId);

                int notReturnedCount = Convert.ToInt32(cmd1.ExecuteScalar());
                if (notReturnedCount > 0)
                {
                    Console.WriteLine("Error: Asset is already allocated and not yet returned.");
                    con.Close();
                    return false;
                }

                // check allocation date after last return date
                string query2 = "select max(return_date) from tblAssetAllocations where asset_id = @asset_id and return_date is not null";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd2.Parameters.AddWithValue("@asset_id", assetId);

                object lastReturnObj = cmd2.ExecuteScalar();
                if (lastReturnObj != DBNull.Value)
                {
                    DateTime lastReturnDate = Convert.ToDateTime(lastReturnObj);
                    if (allocation <= lastReturnDate)
                    {
                        Console.WriteLine("Error: Allocation date must be after the previous return date.");
                        con.Close();
                        return false;
                    }
                }

                // check if allocation date conflicts with reservation
                string query3 = "select count(*) from tblReservations " +
                                "where asset_id = @asset_id and reservation_status = 'approved' " +
                                "and @allocation_date between reservation_start_date and reservation_end_date";
                SqlCommand cmd3 = new SqlCommand(query3, con);
                cmd3.Parameters.AddWithValue("@asset_id", assetId);
                cmd3.Parameters.AddWithValue("@allocation_date", allocation);

                int reservationCount = Convert.ToInt32(cmd3.ExecuteScalar());
                if (reservationCount > 0)
                {
                    Console.WriteLine("Error: Asset is reserved during the given date.");
                    con.Close();
                    return false;
                }

                // check last maintenance date
                string query4 = "select max(maintenance_date) from tblMaintenanceRecords where asset_id = @asset_id";
                SqlCommand cmd4 = new SqlCommand(query4, con);
                cmd4.Parameters.AddWithValue("@asset_id", assetId);

                object maintenanceDateObj = cmd4.ExecuteScalar();
                if (maintenanceDateObj != DBNull.Value)
                {
                    DateTime lastMaintenance = Convert.ToDateTime(maintenanceDateObj);
                    if ((allocation.Year - lastMaintenance.Year) >= 2)
                    {
                        con.Close();
                        throw new AssetNotMaintainException("Cannot allocate asset that is not maintained for 2 or more years.");
                    }
                }
                else
                {
                    Console.WriteLine("Note: No Maintenance Record Found! Assuming asset is new.");
                }

                // allocate the asset
                string query5 = "insert into tblAssetAllocations (asset_id, employee_id, allocation_date) values (@asset_id, @employee_id, @allocation_date)";
                SqlCommand cmd5 = new SqlCommand(query5, con);
                cmd5.Parameters.AddWithValue("@asset_id", assetId);
                cmd5.Parameters.AddWithValue("@employee_id", employeeId);
                cmd5.Parameters.AddWithValue("@allocation_date", allocation);

                int rows = cmd5.ExecuteNonQuery();
                con.Close();
                return rows > 0;
            }
            catch (AssetNotMaintainException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                if (con != null && con.State == ConnectionState.Open) con.Close();
                return false;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error (AllocateAsset): " + ex.Message);
                if (con != null && con.State == ConnectionState.Open) con.Close();
                return false;
            }
        }



        public bool DeAllocateAsset(int assetId, int employeeId, string returnDate)
        {
            try
            {
                con.Open();

                string query = "update tblAssetAllocations set return_date = @return_date " +
                               "where asset_id = @asset_id and employee_id = @employee_id and return_date is null";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@asset_id", assetId);
                cmd.Parameters.AddWithValue("@employee_id", employeeId);
                cmd.Parameters.AddWithValue("@return_date", Convert.ToDateTime(returnDate));

                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected > 0;
            }
            catch (SqlException e)
            {
                Console.WriteLine("SQL Error (DeAllocateAsset): " + e.Message);
                if (con != null && con.State == ConnectionState.Open) con.Close();
                return false;
            }
        }

        public bool PerformMaintenance(int assetId, string maintenanceDate, string maintenanceDescription, double cost)
        {
            try
            {
                con.Open();

                string query = "insert into tblMaintenanceRecords (asset_id, maintenance_date, maintenance_description, cost) " +
                               "values (@asset_id, @maintenance_date, @maintenance_description, @cost)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@asset_id", assetId);
                cmd.Parameters.AddWithValue("@maintenance_date", Convert.ToDateTime(maintenanceDate));
                cmd.Parameters.AddWithValue("@maintenance_description", maintenanceDescription);
                cmd.Parameters.AddWithValue("@cost", cost);

                int rows = cmd.ExecuteNonQuery();
                con.Close();

                return rows > 0;
            }
            catch (SqlException e)
            {
                Console.WriteLine("SQL Error (PerformMaintenance): " + e.Message);
                if (con != null && con.State == ConnectionState.Open) con.Close();
                return false;
            }
        }


        public bool ReserveAsset(int assetId, int employeeId, string reservationDate, string reservationStartDate, string reservationEndDate)
        {
            try
            {
                con.Open();

                string query = "insert into tblReservations (asset_id, employee_id, reservation_date, reservation_start_date, reservation_end_date, reservation_status) " +
                               "values (@asset_id, @employee_id, @reservation_date, @reservation_start_date, @reservation_end_date, 'pending')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@asset_id", assetId);
                cmd.Parameters.AddWithValue("@employee_id", employeeId);
                cmd.Parameters.AddWithValue("@reservation_date", Convert.ToDateTime(reservationDate));
                cmd.Parameters.AddWithValue("@reservation_start_date", Convert.ToDateTime(reservationStartDate));
                cmd.Parameters.AddWithValue("@reservation_end_date", Convert.ToDateTime(reservationEndDate));

                int rows = cmd.ExecuteNonQuery();
                con.Close();

                return rows > 0;
            }
            catch (SqlException e)
            {
                Console.WriteLine("SQL Error (ReserveAsset): " + e.Message);
                if (con != null && con.State == ConnectionState.Open) con.Close();
                return false;
            }
        }


        public bool WithdrawReservation(int reservationId)
        {
            try
            {
                con.Open();

                string query = "update tblReservations set reservation_status = 'cancelled' where reservation_id = @reservation_id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@reservation_id", reservationId);

                int rows = cmd.ExecuteNonQuery();
                con.Close();

                return rows > 0;
            }
            catch (SqlException e)
            {
                Console.WriteLine("SQL Error (WithdrawReservation): " + e.Message);
                if (con != null && con.State == ConnectionState.Open) con.Close();
                return false;
            }
        }







    }
}
