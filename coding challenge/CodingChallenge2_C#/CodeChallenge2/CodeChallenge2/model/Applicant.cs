using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge2.model
{
    class Applicant
    {
        public int ApplicantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Resume { get; set; }

        public Applicant(int id, string fname, string lname, string email, string phone, string resume)
        {
            ApplicantId = id;
            FirstName = fname;
            LastName = lname;
            Email = email;
            Phone = phone;
            Resume = resume;
        }


    }
}
