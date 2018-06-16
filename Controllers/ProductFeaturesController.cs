using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using product_viewer.Models;

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

        [HttpGet("{productId}/productFeatures/{id}", Name = "GetProductFeature")]
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

        [HttpPost("{productId}/productFeatures")]
        public IActionResult CreateProductFeature(int productId, [FromBody] ProductFeatureForCreationDto productFeature) {
            if(null == productFeature) return BadRequest();

            //Description and name can not be the same (for some reason)
            if(productFeature.Name == productFeature.Description) {
                ModelState.AddModelError("Description", "The description must be different to name");
            }

            if(!ModelState.IsValid) return BadRequest(ModelState);

            var product = ProductsDataStore.Current.Products.FirstOrDefault(p => p.Id == productId);

            if(null == product) {
                return NotFound();
            }

            //This is for demo (imporved later in tutorial)
            var topProductFeatureId = ProductsDataStore.Current.Products.SelectMany(p => p.ProductFeatures).Max(c => c.Id);

            var newProductFeature = new ProductFeatureDto() {
                Id = ++topProductFeatureId,
                Name = productFeature.Name,
                Description = productFeature.Description
            };

            product.ProductFeatures.Add(newProductFeature);

            //Note the returned productId is the same as the one that was passed in
            return CreatedAtRoute("GetProductFeature", new { productid = productId, id = newProductFeature.Id}, newProductFeature);
        }
    }
}