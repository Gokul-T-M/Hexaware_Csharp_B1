using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.model
{
    public class User
    {
        public int UserID { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; }
        public string? UserContact { get; set; }
        public string? UserAddress { get; set; }

        public User(int userID, string? userName, string? userEmail, string? userPassword, string? userContact, string? userAddress)
        {
            UserID = userID;
            UserName = userName;
            UserEmail = userEmail;
            UserPassword = userPassword;
            UserContact = userContact;
            UserAddress = userAddress;
        }

        public override string ToString()
        {
            return $"User ID: {UserID}, " +
                   $"Name: {UserName}, " +
                   $"Email: {UserEmail}, " +
                   $"Password: {UserPassword}, " +
                   $"Contact: {UserContact}, " +
                   $"Address: {UserAddress}";
        }


    }


}
