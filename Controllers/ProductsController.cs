using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace product_viewer.Controllers {
    [Route("api/products")]
    public class ProductsController : Controller {
        [HttpGet()]
        public IActionResult GetProducts() {
            return Ok(ProductsDataStore.Current.Products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id) {

            // Find Product
            var product = ProductsDataStore.Current.Products.FirstOrDefault(p => p.Id == id);

            if(null == product) {
                return NotFound();
            }

            return Ok(product);
        }
    }
}