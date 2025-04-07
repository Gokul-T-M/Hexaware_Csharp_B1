using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierManagementSystem.exceptions;
using CourierManagementSystem.model;
using CourierManagementSystem.util;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;

namespace CourierManagementSystem.dao
{
    class CourierUserServiceImpl : ICourierUserService
    {

        private SqlConnection con;//= DBConnUtil.GetConnection("appsettings.json");
       

        public string PlaceOrder(Courier courier)
        {

            con = DBConnUtil.GetConnection("appsettings.json");
            SqlCommand cmd = con.CreateCommand();

            cmd.CommandText = "insert into tblCourier(CourierID,SenderName,SenderAddress,ReceiverName," +
            "ReceiverAddress,CourierWeight,CourierStatus,TrackingNumber,DeliveryDate,UserID,EmployeeID,ServiceID,LocationID) " +
            "values (@CourierID,@SenderName,@SenderAddress,@ReceiverName,@ReceiverAddress,@CourierWeight,@CourierStatus,@TrackingNumber," +
            "@DeliveryDate,@UserID,@EmployeeID,@ServiceID,@LocationID)";
            cmd.Connection = con;

            cmd.Parameters.AddWithValue("@CourierID", courier.CourierID);
            cmd.Parameters.AddWithValue("@SenderName", courier.SenderName);
            cmd.Parameters.AddWithValue("@SenderAddress", courier.SenderAddress);
            cmd.Parameters.AddWithValue("@ReceiverName", courier.ReceiverName);
            cmd.Parameters.AddWithValue("@ReceiverAddress", courier.ReceiverAddress);
            cmd.Parameters.AddWithValue("@CourierWeight", courier.CourierWeight);
            cmd.Parameters.AddWithValue("@CourierStatus", courier.CourierStatus);
            cmd.Parameters.AddWithValue("@TrackingNumber", courier.TrackingNumber);
            cmd.Parameters.AddWithValue("@DeliveryDate", courier.DeliveryDate);

            cmd.Parameters.AddWithValue("@UserID", courier.UserID);
            cmd.Parameters.AddWithValue("@EmployeeID", courier.EmployeeID);
            cmd.Parameters.AddWithValue("@ServiceID", courier.ServiceID);
            cmd.Parameters.AddWithValue("@LocationID", courier.LocationID);
            
            con.Open();
            int rows = cmd.ExecuteNonQuery();
            con.Close();

            if (rows > 0)
            {
                return "Value added into Couriers Successfully!";
            }
            else
            {
                return "Problem adding values to Couriers";
            }


        }
        public string GetOrderStatus(string trackingNumber)
        {
            con = DBConnUtil.GetConnection("appsettings.json");
            SqlCommand cmd = new SqlCommand("select CourierStatus from tblCourier where TrackingNumber = @TrackingNumber", con);

            cmd.Parameters.AddWithValue("@TrackingNumber", trackingNumber);


            con.Open();
            string orderStatus = (string)cmd.ExecuteScalar();
            con.Close();
            if (orderStatus == null)
            {
                throw (new TrackingNumberNotFoundException("Tracking Number Not Found ! "));
            }

            return orderStatus;

        }
        public bool CancelOrder(string trackingNumber)
        {
            con = DBConnUtil.GetConnection("appsettings.json");
            SqlCommand cmd = new SqlCommand("update tblCourier set CourierStatus = 'Order Cancelled' where TrackingNumber = @trackingNumber", con);

            cmd.Parameters.AddWithValue("@trackingNumber", trackingNumber);

            con.Open();
            int rows = cmd.ExecuteNonQuery();
            con.Close();

            if(rows == 0)
            {
                throw new TrackingNumberNotFoundException("Tracking Number not found for Cancelling the Courier Order");
            }
            return true;

        }

        public List<Courier> GetAssignedOrder(int employeeId)
        {
            List<Courier> assignedCouriers = new List<Courier>();

            
                con = DBConnUtil.GetConnection("appsettings.json");
             
                SqlCommand cmd = new SqlCommand("Select * from tblCourier where EmployeeID = @employeeId", con);
                cmd.Parameters.AddWithValue("@employeeId", employeeId);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Courier courier = new Courier(

                        Convert.ToInt32(dr["CourierID"]),
                        Convert.ToString(dr["SenderName"]),
                        Convert.ToString(dr["SenderAddress"]),
                        Convert.ToString(dr["ReceiverName"]),
                        Convert.ToString(dr["ReceiverAddress"]),
                        Convert.ToDecimal(dr["CourierWeight"]),
                        Convert.ToString(dr["CourierStatus"]),
                        Convert.ToString(dr["TrackingNumber"]),
                        Convert.ToDateTime(dr["DeliveryDate"]),
                        Convert.ToInt32(dr["UserID"]),
                        Convert.ToInt32(dr["EmployeeID"]),
                        Convert.ToInt32(dr["ServiceID"]),
                        Convert.ToInt32(dr["LocationID"])
                        );

                    assignedCouriers.Add(courier);
                }
            
            con.Close();

            if (assignedCouriers.Count == 0) throw new InvalidEmployeeIDException("Entered EmployeeID is Invalid!");

            return assignedCouriers;


        }

        public List<Courier> RetrieveDeliveryHistory(string trackingNumber)
        {
            List<Courier> history = new List<Courier>();

            con = DBConnUtil.GetConnection("appsettings.json");
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblCourier WHERE TrackingNumber = @TrackingNumber", con);
            cmd.Parameters.AddWithValue("@TrackingNumber", trackingNumber);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Courier courier = new Courier(
                    Convert.ToInt32(dr["CourierID"]),
                    Convert.ToString(dr["SenderName"]),
                    Convert.ToString(dr["SenderAddress"]),
                    Convert.ToString(dr["ReceiverName"]),
                    Convert.ToString(dr["ReceiverAddress"]),
                    Convert.ToDecimal(dr["CourierWeight"]),
                    Convert.ToString(dr["CourierStatus"]),
                    Convert.ToString(dr["TrackingNumber"]),
                    Convert.ToDateTime(dr["DeliveryDate"]),
                    Convert.ToInt32(dr["UserID"]),
                    Convert.ToInt32(dr["EmployeeID"]),
                    Convert.ToInt32(dr["ServiceID"]),
                    Convert.ToInt32(dr["LocationID"])
                );

                history.Add(courier);
            }

            dr.Close();
            con.Close();

            if (history.Count == 0)
            {
                throw new TrackingNumberNotFoundException("Tracking Number Not Found!");
            }

            return history;
        }

        public Dictionary<int, decimal> GenerateRevenueReportByLocationId()
        {
            Dictionary<int, decimal> revenueByLocation = new Dictionary<int, decimal>();

            con = DBConnUtil.GetConnection("appsettings.json");
            string query = @"SELECT LocationID, SUM(Amount) as TotalRevenue 
                     FROM tblPayment 
                     GROUP BY LocationID";

            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int locationId = Convert.ToInt32(reader["LocationID"]);
                    decimal revenue = Convert.ToDecimal(reader["TotalRevenue"]);

                    revenueByLocation.Add(locationId, revenue);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching revenue by location: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            return revenueByLocation;
        }



    }
}
