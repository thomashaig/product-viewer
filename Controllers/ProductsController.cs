using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace product_viewer.Controllers {
    [Route("api/products")]
    public class ProductsController : Controller {
        [HttpGet()]
        public JsonResult GetProducts() {
            return new JsonResult(ProductsDataStore.Current.Products);
        }

        [HttpGet("{id}")]
        public JsonResult GetProduct(int id) {
            return new JsonResult(ProductsDataStore.Current.Products.FirstOrDefault(p => p.Id == id));
        }
    }
}