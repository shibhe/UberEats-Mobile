using System;
namespace UberEats.Model
{
    public class Customer
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string creditCard { get; set; }
        public string CVV { get; set; }
        public System.DateTime expiryDate { get; set; }
        public string zipCode { get; set; }
        public string userRole { get; set; }
    }
}
