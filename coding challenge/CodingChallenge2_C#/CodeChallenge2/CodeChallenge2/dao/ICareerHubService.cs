using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeChallenge2.model;

namespace CodeChallenge2.dao
{
    interface ICareerHubService
    {
        void InsertCompany(Company company);
        void InsertJobListing(JobListing job);
        void InsertApplicant(Applicant applicant);
        void InsertJobApplication(JobApplication application);

        List<Company> GetCompanies();
        List<JobListing> GetJobListings();
        List<Applicant> GetApplicants();
        List<JobApplication> GetApplicationsForJob(int jobId);
    }
}
