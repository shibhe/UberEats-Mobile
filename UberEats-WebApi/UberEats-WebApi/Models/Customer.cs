using System;
namespace UberEatsWebApi.Models
{
    public class Customer
    {
        private long v1;
        private string v2;
        private string v3;
        private string v4;
        private string v5;
        private string v6;
        private string v7;
        private string v8;
        private string v9;
        private string v10;

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

        public Customer(int CustID, string firstName, string lastName, string phoneNumber, string email, string password, string CreditCard, string CVV, string ExpiryDate, string ZipCode, string UserRole)
        {
            Id = CustID;
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            this.CVV = CVV;
            this.ZipCode = ZipCode;
            this.CreditCard = CreditCard;
            this.ExpiryDate = ExpiryDate;
            this.UserRole = UserRole;

        }
    }
}
