using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge2.model
{
    class JobApplication
    {
        public int ApplicationId { get; set; }
        public int JobId { get; set; }
        public int ApplicantId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string CoverLetter { get; set; }

        public JobApplication(int id, int jobId, int applicantId, DateTime date, string coverLetter)
        {
            ApplicationId = id;
            JobId = jobId;
            ApplicantId = applicantId;
            ApplicationDate = date;
            CoverLetter = coverLetter;
        }
    }
}
