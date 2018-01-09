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
    public class ProductsController : System.Web.Http.ApiController
    {
		readonly DBConnect obj = new DBConnect();

		//Get all the restaurants information stored in the database
		[System.Web.Http.HttpGet]
		[System.Web.Http.Route("api/Product")]
		public IEnumerable<Products> GetAllProducts()
		{
            return obj.GetProduct();
		}

		[ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(Products products)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

           // obj.AddCust(products);

            return CreatedAtRoute("DefaultApi", new { id = products.Id }, products);
		}
    }
}
