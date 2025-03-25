--1. Provide a SQL script that initializes the database for the Job Board scenario “CareerHub”

use master

create database careerhub;
use careerhub;

--2. Create tables for Companies, Jobs, Applicants and Applications. 
--3. Define appropriate primary keys, foreign keys, and constraints.
--4. Ensure the script handles potential errors, such as if the database or tables already exist

IF OBJECT_ID('dbo.tblCompanies', 'U') IS NULL
begin

create table tblCompanies (
    companyId int primary key,
    companyName varchar(255),
    companyLocation varchar(255)
)

end


IF OBJECT_ID('dbo.tblJobs', 'U') IS NULL
begin

create table tblJobs (
    jobId int primary key,
    companyId int,
    jobTitle varchar(255),
    jobDescription text,
    jobLocation varchar(255),
    jobSalary decimal(10,2),
    jobType varchar(50),
    postedDate datetime,
    foreign key (companyId) references tblCompanies(companyId)
);

end

IF OBJECT_ID('dbo.tblApplicants', 'U') IS NULL
begin

create table tblApplicants (
    applicantId int primary key,
    firstName varchar(255),
    lastName varchar(255),
    email varchar(255) unique,
    phone varchar(15) unique,
    applicantResume text
);

end

IF OBJECT_ID('dbo.tblApplications', 'U') IS NULL
begin

create table tblApplications (
    applicationId int primary key,
    jobId int,
    applicantId int,
    applicationDate datetime,
    coverLetter text,
    foreign key (jobId) references tblJobs(jobId),
    foreign key (applicantId) references tblApplicants(applicantId)
);

end



insert into tblCompanies values
(1, 'Hexaware Technologies', 'Chennai'),
(2, 'TCS', 'Bangalore'),
(3, 'Infosys', 'Pune'),
(4, 'Wipro', 'Hyderabad'),
(5, 'HCL', 'Noida'),
(6, 'Capgemini', 'Mumbai'),
(7, 'Cognizant', 'Kolkata');


insert into tblJobs values
(1, 1, 'Software Developer', 'Develop and maintain software applications.', 'Chennai', 75000, 'Full-time', '2024-01-15'),
(2, 1, 'Data Scientist', 'Work with AI and ML models.', 'Chennai', 120000, 'Full-time', '2024-02-10'),
(3, 2, 'Data Analyst', 'Analyze and interpret complex data.', 'Bangalore', 65000, 'Full-time', '2024-03-05'),
(4, 3, 'System Engineer', 'Manage system infrastructure.', 'Pune', 70000, 'Contract', '2024-02-22'),
(5, 3, 'Cloud Engineer', 'Work on AWS and Azure cloud services.', 'Pune', 90000, 'Full-time', '2024-03-12'),
(6, 4, 'Network Engineer', 'Configure and manage networks.', 'Hyderabad', 80000, 'Full-time', '2024-01-28'),
(7, 5, 'Full Stack Developer', 'Develop frontend and backend applications.', 'Noida', 95000, 'Part-time', '2024-02-18'),
(8, 6, 'Cybersecurity Analyst', 'Ensure data security and compliance.', 'Mumbai', 110000, 'Full-time', '2024-02-25'),
(9, 7, 'Business Analyst', 'Analyze business requirements.', 'Kolkata', 72000, 'Contract', '2024-03-10');

insert into tblApplicants values
(1, 'Rahul', 'Sharma', 'rahul@example.com', '9876543210', 'Experience: 3 years in Java development'),
(2, 'Priya', 'Verma', 'priya@example.com', '9876543211', 'Experience: 2 years in Data Analytics'),
(3, 'Anil', 'Kumar', 'anil@example.com', '9876543212', 'Experience: 5 years in System Engineering'),
(4, 'Neha', 'Gupta', 'neha@example.com', '9876543213', 'Experience: 1 year in Networking'),
(5, 'Vikram', 'Singh', 'vikram@example.com', '9876543214', 'Experience: 4 years in Full Stack Development'),
(6, 'Sandeep', 'Reddy', 'sandeep@example.com', '9876543215', 'Experience: 6 years in Cybersecurity'),
(7, 'Megha', 'Iyer', 'megha@example.com', '9876543216', 'Experience: 3 years in Cloud Engineering'),
(8, 'Ramesh', 'Yadav', 'ramesh@example.com', '9876543217', 'Experience: 2 years in Business Analysis'),
(9, 'Pooja', 'Agarwal', 'pooja@example.com', '9876543218', 'Experience: 4 years in Software Development'),
(10, 'Arjun', 'Raj', 'arjun@example.com', '9876543219', 'Experience: 7 years in Data Science');

insert into tblApplications values
(1, 1, 1, '2024-03-01', 'Excited to apply for this Software Developer role at Hexaware.'),
(2, 1, 9, '2024-03-05', 'I have experience in software development and would love to contribute.'),
(3, 2, 10, '2024-03-08', 'Applying for Data Scientist role with strong ML expertise.'),
(4, 3, 2, '2024-03-10', 'Looking forward to applying my Data Analytics skills at TCS.'),
(5, 4, 3, '2024-03-12', '5 years of System Engineering experience.'),
(6, 5, 7, '2024-03-14', 'Skilled in AWS and Azure, excited about Cloud Engineer role.'),
(7, 6, 4, '2024-03-15', 'Passionate about networking and security.'),
(8, 7, 5, '2024-03-16', 'Full Stack Development is my expertise, excited for this opportunity.'),
(9, 8, 6, '2024-03-18', 'Applying for Cybersecurity Analyst with 6 years of experience.'),
(10, 9, 8, '2024-03-19', '2 years of Business Analysis experience, eager to work with Cognizant.'),
(11, 1, 5, '2024-03-20', 'Applying again for Software Developer with additional skills.'),
(12, 3, 8, '2024-03-22', 'Interested in Data Analyst position at TCS.');


select * from tblApplicants;

select * from tblApplications

select * from tblCompanies

select * from tblJobs

--5. Write an SQL query to count the number of applications received for each job listing in the
--"Jobs" table. Display the job title and the corresponding application count. Ensure that it lists all
--jobs, even if they have no applications.

select j.jobId,j.jobTitle, count(a.applicationId) as applicationCount
from tblJobs j
left join tblApplications a on j.jobId = a.jobId
group by j.jobId, j.jobTitle;


---6. Develop an SQL query that retrieves job listings from the "Jobs" table within a specified salary
--range. Allow parameters for the minimum and maximum salary values. Display the job title,
--company name, location, and salary for each matching job.

declare @minSalary decimal(10,2) = 60000;
declare @maxSalary decimal(10,2) = 80000;

select j.jobTitle, c.companyName, j.jobLocation, j.jobSalary
from tblJobs j
join tblCompanies c on j.companyId = c.companyId
where j.jobSalary between @minSalary and @maxSalary;

--7. Write an SQL query that retrieves the job application history for a specific applicant. Allow a
--parameter for the ApplicantID, and return a result set with the job titles, company names, and
--application dates for all the jobs the applicant has applied to.

declare @applicantId int = 1; 

select j.jobTitle, c.companyName, a.applicationDate
from tblApplications a
join tblJobs j on a.jobId = j.jobId
join tblCompanies c on j.companyId = c.companyId
where a.applicantId = @applicantId;

--8. Create an SQL query that calculates and displays the average salary offered by all companies for
--job listings in the "Jobs" table. Ensure that the query filters out jobs with a salary of zero.

select avg(j.jobSalary) as avgSalary
from tblJobs j
where j.jobSalary > 0;

--9. Write an SQL query to identify the company that has posted the most job listings. Display the
--company name along with the count of job listings they have posted. Handle ties if multiple
--companies have the same maximum count.


select top 1 c.companyName, count(j.jobId) as jobCount
from tblCompanies c
join tblJobs j on c.companyId = j.companyId
group by c.companyName
order by jobCount desc;


--10. Find the applicants who have applied for positions in companies located in 'CityX' and have at
--least 3 years of experience

--assuming cityX = chennai

select distinct a.applicantId, a.firstName, a.lastName
from tblApplicants a
join tblApplications app on a.applicantId = app.applicantId
join tblJobs j on app.jobId = j.jobId
join tblCompanies c on j.companyId = c.companyId
where c.companyLocation = 'Chennai' and a.applicantResume not like '%[0-2] years%'

--11. Retrieve a list of distinct job titles with salaries between $60,000 and $80,000.

select distinct jobTitle,jobSalary from tbljobs j
where jobSalary between 60000 and 80000

--12. Find the jobs that have not received any applications.select j.jobId,j.jobTitle from tblJobs jwhere not exists (select 1 from tblApplications twhere j.jobId=t.jobId)--13. Retrieve a list of job applicants along with the companies they have applied to and the positions
--they have applied for.

select a.firstName, a.lastName, c.companyName, j.jobTitle
from tblApplications app
join tblApplicants a on app.applicantId = a.applicantId
join tblJobs j on app.jobId = j.jobId
join tblCompanies c on j.companyId = c.companyId;


--14. Retrieve a list of companies along with the count of jobs they have posted, even if they have not
--received any applications.select * from tblApplicants;
select * from tblApplications
select * from tblCompanies
select * from tblJobs
select c.companyName, count(j.jobId) as jobCount
from tblCompanies c
left join tblJobs j on c.companyId = j.companyId
group by c.companyName;
--15. List all applicants along with the companies and positions they have applied for, including those
--who have not applied.select a.firstName, a.lastName, c.companyName, j.jobTitle
from tblApplicants a
left join tblApplications app on a.applicantId = app.applicantId
left join tblJobs j on app.jobId = j.jobId
left join tblCompanies c on j.companyId = c.companyId;
--16. Find companies that have posted jobs with a salary higher than the average salary of all jobs.select * from tblCompanies where companyId in (select companyId from tblJobs where jobSalary > (select avg(jobSalary) from tblJobs))--17. Display a list of applicants with their names and a concatenated string of their city and state.(city and state info not given)select distinct a.firstName, a.lastName, c.companyLocation + ', state not given' as location
from tblApplicants a
join tblApplications app on a.applicantId = app.applicantId
join tblJobs j on app.jobId = j.jobId
join tblCompanies c on j.companyId = c.companyId;


--18. Retrieve a list of jobs with titles containing either 'Developer' or 'Engineer'
select * from tblJobs where jobTitle like '%Developer%'or jobTitle like '%Engineer%';--19. Retrieve a list of applicants and the jobs they have applied for, including those who have not
--applied and jobs without applicants.

select a.firstName, a.lastName, j.jobTitle
from tblApplicants a
left join tblApplications app on a.applicantId = app.applicantId
left join tblJobs j on app.jobId = j.jobId;


--20. List all combinations of applicants and companies where the company is in a specific city and the
--applicant has more than 2 years of experience. For example: city=Chennai

select a.firstName, a.lastName, c.companyName
from tblApplicants a
join tblApplications app on a.applicantId = app.applicantId
join tblJobs j on app.jobId = j.jobId
join tblCompanies c on j.companyId = c.companyId
where c.companyLocation = 'Chennai' and a.applicantResume not like '%[0-2] years%';

