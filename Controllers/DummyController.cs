using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using product_viewer.Entities;

namespace product_viewer.Controllers {
    public class DummyController : Controller {
        private ProductInfoContext _ctx;

        public DummyController(ProductInfoContext ctx) {
            _ctx = ctx;
        }

        [HttpGet]
        [Route("api/testdatabase")]
        public IActionResult TestDatabase() {
            return Ok();
        }
    }
}