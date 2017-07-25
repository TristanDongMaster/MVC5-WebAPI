﻿using ProductsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace ProductsApp.Controllers
{
    public class ProductsController : ApiController
    {
        Product[] products = new Product[] 
        { 
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 }, 
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M }, 
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M } 
        };

        [Route("api/products")]
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        [Route("api/products/{id}")]
        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

		[Route("api/products/get/{id}")]
		public IHttpActionResult GetOnlyProduct(int id)
		{
            Product[] product = new Product[]
            {
                new Product { Id = id, Name = "Tomato Soup" + id, Category = "Groceries" + id, Price = 1 },
            };
			return Ok(product);
		}
	}
}
