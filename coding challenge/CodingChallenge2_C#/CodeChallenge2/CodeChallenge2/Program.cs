using CodeChallenge2.dao;
using CodeChallenge2.exception;
using CodeChallenge2.model;

namespace CodeChallenge2
{
    internal class Program
    {
        static ICareerHubService service = new CareerHubServiceImpl();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n---- CareerHub Menu ----");
                Console.WriteLine("1. Insert Company");
                Console.WriteLine("2. Insert Job Listing");
                Console.WriteLine("3. Insert Applicant");
                Console.WriteLine("4. Insert Job Application");
                Console.WriteLine("5. Get Job Listings");
                Console.WriteLine("6. Get Companies");
                Console.WriteLine("7. Get Applicants");
                Console.WriteLine("8. Get Applications for Job");
                Console.WriteLine("9. Exit");
                Console.Write("Enter your choice: ");

                int choice;
                bool isNumber = int.TryParse(Console.ReadLine(), out choice);
                if (!isNumber)
                {
                    Console.WriteLine("Enter valid number!");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        InsertCompany(); 
                       
                        break;
                    case 2:
                        try
                        {
                            InsertJobListing();
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                         break;
                    case 3:

                        try
                        {
                            InsertApplicant();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 4:
                        try
                        {
                            InsertJobApplication();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 5:
                        GetJobListings(); 
                        break;
                    case 6:
                        GetCompanies();
                        break;
                    case 7:
                        GetApplicants(); 
                        break;
                    case 8:
                        GetApplicationsForJob(); 
                        break;
                    case 9:
                        Console.WriteLine("Exit");
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Please enter a valid choice");
                        break;
                }
            }
        }

        private static void InsertCompany()
        {
            Console.Write("Enter Company ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Company Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Location: ");
            string location = Console.ReadLine();

            Company company = new Company(id, name, location);
            service.InsertCompany(company);

            Console.WriteLine("Company inserted");
        }

        private static void InsertJobListing()
        {
            Console.Write("Enter Job ID: ");
            int jobId = int.Parse(Console.ReadLine());

            Console.Write("Enter Company ID: ");
            int companyId = int.Parse(Console.ReadLine());

            Console.Write("Enter Job Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter Job Description: ");
            string desc = Console.ReadLine();

            Console.Write("Enter Job Location: ");
            string location = Console.ReadLine();

            Console.Write("Enter Salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());

            if (salary < 0) throw new NegativeSalaryException("Salary can't be negative!");

            Console.Write("Enter Job Type: ");
            string type = Console.ReadLine();

            DateTime posted = DateTime.Now;

            JobListing job = new JobListing(jobId, companyId, title, desc, location, salary, type, posted);
            service.InsertJobListing(job);


            Console.WriteLine("job listed!");
        }

        private static void InsertApplicant()
        {
            Console.Write("Enter Applicant ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter First Name: ");
            string fname = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            string lname = Console.ReadLine();


            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            if (!email.Contains("@") || !email.Contains("."))
                throw new InvalidEmailFormatException("Invalid email format!");

            Console.Write("Enter Phone: ");
            string phone = Console.ReadLine();
            Console.Write("Enter Resume Text: ");
            string resume = Console.ReadLine();

            Applicant applicant = new Applicant(id, fname, lname, email, phone, resume);
            service.InsertApplicant(applicant);


            Console.WriteLine("applicant inserted");
        }

        private static void InsertJobApplication()
        {
            Console.Write("Enter Application ID: ");
            int appId = int.Parse(Console.ReadLine());

            Console.Write("Enter Job ID: ");
            int jobId = int.Parse(Console.ReadLine());

            Console.Write("Enter Applicant ID: ");
            int applicantId = int.Parse(Console.ReadLine());

            DateTime deadline = new DateTime(2024, 1, 1);

            if (DateTime.Now > deadline)
                throw new ApplicationDeadlinePassedException("Deadline Passed. Cannot Apply.");

            Console.Write("Enter Cover Letter: ");
            string cover = Console.ReadLine();

            DateTime applied = DateTime.Now;

            JobApplication jobApp = new JobApplication(appId, jobId, applicantId, applied, cover);
            service.InsertJobApplication(jobApp);


            Console.WriteLine("Application inserted");
        }

        private static void GetJobListings()
        {
            List<JobListing> jobs = service.GetJobListings();

            Console.WriteLine("\n--- All Jobs ---");
            Console.WriteLine("JobId | CompanyId | JobTitle | JobLocation | Salary | JobType | PostedDate");

            foreach (var j in jobs)
            {
                Console.WriteLine($"{j.JobId} | {j.CompanyId} | {j.JobTitle} | {j.JobLocation} | {j.Salary} | {j.JobType} | {j.PostedDate}");
            }
        }

        private static void GetCompanies()
        {
            List<Company> companies = service.GetCompanies();
            Console.WriteLine("\n--- All Companies ---");
            Console.WriteLine("CompanyId | CompanyName | Location");

            foreach (var c in companies)
            {
                Console.WriteLine($"{c.CompanyId} | {c.CompanyName} | {c.Location}");
            }
        }

        private static void GetApplicants()
        {
            List<Applicant> applicants = service.GetApplicants();
            Console.WriteLine("\n--- All Applicants ---");
            Console.WriteLine("ApplicantId | FullName | Email | Phone | Resume");

            foreach (var a in applicants)
            {
                Console.WriteLine($"{a.ApplicantId} | {a.FirstName} {a.LastName} | {a.Email} | {a.Phone} | {a.Resume}");
            }
        }

        private static void GetApplicationsForJob()
        {
            Console.Write("Enter Job ID to see applications: ");
            int jobId = int.Parse(Console.ReadLine());
            List<JobApplication> apps = service.GetApplicationsForJob(jobId);

            Console.WriteLine($"\n--- Applications for Job ID {jobId} ---");
            Console.WriteLine("ApplicationId | ApplicantId | CoverLetter");

            foreach (var app in apps)
            {
                Console.WriteLine($"{app.ApplicationId} | {app.ApplicantId} | {app.CoverLetter}");
            }
        }
    }
}
