using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge2.model
{
    class JobListing
    {
        public int JobId { get; set; }
        public int CompanyId { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string JobLocation { get; set; }
        public decimal Salary { get; set; }
        public string JobType { get; set; }
        public DateTime PostedDate { get; set; }

        public JobListing(int jobId, int companyId, string title, string description, string location, decimal salary, string jobType, DateTime postedDate)
        {
            JobId = jobId;
            CompanyId = companyId;
            JobTitle = title;
            JobDescription = description;
            JobLocation = location;
            Salary = salary;
            JobType = jobType;
            PostedDate = postedDate;
        }
    }
}
