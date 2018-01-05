using System;
namespace UberEatsWebApi.Models
{
    public class Customer
    {
        public Customer()
        {
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CreditCard { get; set; }
        public string CVV { get; set; }
        public string ExpiryDate { get; set; }
        public string ZipCode { get; set; }
        public string UserRole { get; set; }

        public Customer(string email, string password, string mobile, string firstname, string lastname)
        {
            Email = email;
            Password = password;
            FirstName = firstname;
            LastName = lastname;
            PhoneNumber = mobile;
        }

        public Customer(int CustID, string email, string mobile, string password, string firstname, string lastname)
        {
            Id = CustID;
            Email = email;
            Password = password;
            FirstName = firstname;
            LastName = lastname;
            PhoneNumber = mobile;

        }

        public Customer(string mobile, string firstname, string lastname)
        {

            FirstName = firstname;
            LastName = lastname;
            PhoneNumber = mobile;

        }
    }
}
