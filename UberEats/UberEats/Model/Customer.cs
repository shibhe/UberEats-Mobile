using System;
namespace UberEats.Model
{
    public class Customer
    {
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
    }
}
