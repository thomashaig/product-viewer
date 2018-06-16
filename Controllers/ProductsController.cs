using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace product_viewer.Controllers {
    public class ProductsController : Controller {
        [HttpGet("api/products")]
        public JsonResult GetProducts() {
            return new JsonResult(new List<object>() {
                new { id=1, name="Product 1" },
                new { id=2, name="Product 2"}
            });
        
        }
    }
}