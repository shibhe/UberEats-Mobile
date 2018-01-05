using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using UberEatsWebApi.Data;
using UberEatsWebApi.Models;


namespace UberEatsWebApi.Controllers
{
    public class CustomersController : System.Web.Http.ApiController
    {
        readonly DBConnect obj = new DBConnect();


		//Retrive customer information from database
		//Registering customers on the mobile application
		// [HttpPost]
		// POST: [Route("api/Customers")]
		//[Route("api/Customers")]
		[ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(Customer customer)
        {
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

             obj.AddCust(customer);

             return CreatedAtRoute("DefaultApi", new { id = customer.Id }, customer);
        }


        //Login into the system
        public Customer GetCustomer(string email, string password)
        {
			 return obj.CustomerLogin(email, password);
			
        }

        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/CustomerUpdate")]
        public Customer PutCustomer(Customer cust, int id)
        {
            return obj.CustomerUpdate(cust, id);
        }
    }
}
