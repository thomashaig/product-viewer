using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace product_viewer.Controllers {
    [Route("api/products")]
    public class ProductFeaturesController : Controller {
        [HttpGet("{productId}/productFeatures")]
        public IActionResult GetProductFeatures(int productId) {
             // Find Parent Product
            var product = ProductsDataStore.Current.Products.FirstOrDefault(p => p.Id == productId);

            if(null == product) {
                return NotFound();
            }

            return Ok(product.ProductFeatures);
        }

        [HttpGet("{productId}/productFeatures/{id}")]
        public IActionResult GetProductFeature(int productId, int id) {
             // Find Parent Product
            var product = ProductsDataStore.Current.Products.FirstOrDefault(p => p.Id == productId);

            if(null == product) {
                return NotFound();
            }

            var feature = product.ProductFeatures.FirstOrDefault(f => f.Id == id);

            if(null == feature) {
                return NotFound();
            }

            return Ok(feature);
        }
    }
}