using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeChallenge2.exception;
using CodeChallenge2.model;
using CourierManagementSystem.util;
using Microsoft.Data.SqlClient;

namespace CodeChallenge2.dao
{
    class CareerHubServiceImpl : ICareerHubService
    {
        private SqlConnection con;

        public CareerHubServiceImpl()
        {
                con = DBConnUtil.GetConnection("appsettings.json");
     
            
        }
         


        public void InsertCompany(Company company)
        {
            try
            {
                con.Open();
                string query = "insert into tblcompanies values (@companyId, @companyName, @location)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@companyId", company.CompanyId);
                cmd.Parameters.AddWithValue("@companyName", company.CompanyName);
                cmd.Parameters.AddWithValue("@location", company.Location);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error while inserting company: " + ex.Message);
            }
            finally 
            { 
                con.Close();
            }
        }

        public void InsertJobListing(JobListing job)
        {
            try
            {
                con.Open();
                string query = "insert into tbljobs values (@jobId, @companyId, @title, @desc, @loc, @sal, @type, @date)";
                SqlCommand cmd = new SqlCommand(query, con);


                cmd.Parameters.AddWithValue("@jobId", job.JobId);
                cmd.Parameters.AddWithValue("@companyId", job.CompanyId);
                cmd.Parameters.AddWithValue("@title", job.JobTitle);
                cmd.Parameters.AddWithValue("@desc", job.JobDescription);
                cmd.Parameters.AddWithValue("@loc", job.JobLocation);
                cmd.Parameters.AddWithValue("@sal", job.Salary);
                cmd.Parameters.AddWithValue("@type", job.JobType);
                cmd.Parameters.AddWithValue("@date", job.PostedDate);


                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error while inserting job listing: " + ex.Message);
            }
            finally 
            { 
                con.Close();
            }
        }

        public void InsertApplicant(Applicant applicant)
        {
            try
            {
                con.Open();
                string query = "insert into tblapplicants values (@id, @fname, @lname, @email, @phone, @resume)";


                SqlCommand cmd = new SqlCommand(query, con);


                cmd.Parameters.AddWithValue("@id", applicant.ApplicantId);
                cmd.Parameters.AddWithValue("@fname", applicant.FirstName);
                cmd.Parameters.AddWithValue("@lname", applicant.LastName);
                cmd.Parameters.AddWithValue("@email", applicant.Email);
                cmd.Parameters.AddWithValue("@phone", applicant.Phone);
                cmd.Parameters.AddWithValue("@resume", applicant.Resume);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error while inserting applicant: " + ex.Message);
            }

            finally 
            { 
                con.Close(); 
            }
        }

        public void InsertJobApplication(JobApplication application)
        {
            try
            {
                con.Open();
                string query = "insert into tblapplications values (@id, @jobId, @appId, @date, @letter)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", application.ApplicationId);
                cmd.Parameters.AddWithValue("@jobId", application.JobId);
                cmd.Parameters.AddWithValue("@appId", application.ApplicantId);
                cmd.Parameters.AddWithValue("@date", application.ApplicationDate);
                cmd.Parameters.AddWithValue("@letter", application.CoverLetter);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error while inserting application: " + ex.Message);
            }
            finally 
            {
                con.Close(); 
            }
        }

        public List<Company> GetCompanies()
        {
            List<Company> list = new List<Company>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from tblcompanies", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new Company(
                    Convert.ToInt32(dr["companyId"]),
                    Convert.ToString(dr["companyName"]),
                    Convert.ToString(dr["companyLocation"])
                ));

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error fetching companies: " + ex.Message);
            }
            finally 
            { 
                con.Close(); 
            }
            return list;
        }

        public List<JobListing> GetJobListings()
        {
            List<JobListing> list = new List<JobListing>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from tbljobs", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new JobListing(
                    Convert.ToInt32(dr["jobId"]),
                    Convert.ToInt32(dr["companyId"]),
                    Convert.ToString(dr["jobTitle"]),
                    Convert.ToString(dr["jobDescription"]),
                    Convert.ToString(dr["jobLocation"]),
                    Convert.ToDecimal(dr["jobSalary"]),
                    Convert.ToString(dr["jobType"]),
                    Convert.ToDateTime(dr["postedDate"])
                ));

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error fetching jobs: " + ex.Message);
            }
            finally 
            { 
                con.Close();
            }
            return list;
        }

        public List<Applicant> GetApplicants()
        {
            List<Applicant> list = new List<Applicant>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from tblapplicants", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                   list.Add(new Applicant(
                   Convert.ToInt32(dr["applicantId"]),
                   Convert.ToString(dr["firstName"]),
                   Convert.ToString(dr["lastName"]),
                   Convert.ToString(dr["email"]),
                   Convert.ToString(dr["phone"]),
                   Convert.ToString(dr["applicantResume"])
               ));

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error fetching applicants: " + ex.Message);
            }
            finally 
            { 
                con.Close(); 
            }
            return list;
        }

        public List<JobApplication> GetApplicationsForJob(int jobId)
        {
            List<JobApplication> list = new List<JobApplication>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from tblapplications where jobId = @jobId", con);
                cmd.Parameters.AddWithValue("@jobId", jobId);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new JobApplication(
                    
                        Convert.ToInt32(dr["applicationId"]),
                        Convert.ToInt32(dr["jobId"]),
                        Convert.ToInt32(dr["applicantId"]),
                        Convert.ToDateTime(dr["applicationDate"]),
                        Convert.ToString(dr["coverLetter"])
                    ));
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error fetching applications: " + ex.Message);
            }
            finally { con.Close(); }
            return list;
        }
    }
}
