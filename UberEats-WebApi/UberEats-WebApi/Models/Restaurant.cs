using System;
namespace UberEatsWebApi.Models
{
    public class Restaurant
    {
		public int Id { get; set; }
		public string firstName { get; set; }
		public string lastName { get; set; }
		public string phoneNumber { get; set; }
		public string email { get; set; }
		public string password { get; set; }
		public string city { get; set; }
		public string title { get; set; }
		public string RestName { get; set; }
		public int numOfLocation { get; set; }
		public string typeOfCuisine { get; set; }
		public string estweeklyOrder { get; set; }
		public string offerDelivery { get; set; }
		public string zipCode { get; set; }
		public string userRole { get; set; }


		public Restaurant(int Id, string firstName, string lastName, string phoneNumber, string email, string password,
                          string city, string title,string RestName, int numOfLocation, string typeOfCuisine,
                          string estweeklyOrder,string offerDelivery,string zipCode, string userRole)
		{
            this.Id = Id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.password = password;
            this.city = city;
            this.title = title;
            this.RestName = RestName;
            this.numOfLocation = numOfLocation;
            this.typeOfCuisine = typeOfCuisine;
            this.estweeklyOrder = estweeklyOrder;
            this.offerDelivery = offerDelivery;
            this.zipCode = zipCode;
            this.userRole = userRole;

		}
    }
}
