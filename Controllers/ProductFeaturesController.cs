using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using product_viewer.Models;
using Microsoft.AspNetCore.JsonPatch;

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

        [HttpPut("{productId}/productFeatures/{id}")]
        public IActionResult UpdateProductFeature(int productId, int id, [FromBody] ProductFeatureForUpdateDto productFeature) {
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

            var productFeatureToPut = product.ProductFeatures.FirstOrDefault(f => f.Id == id);

            if(null == productFeature) {
                return NotFound();
            }

            productFeatureToPut.Name = productFeature.Name;
            productFeatureToPut.Description = productFeature.Description;

            return NoContent();
        }

        [HttpPatch("{productId}/productFeatures/{id}")]
        public IActionResult PartialUpdateProductFeature(int productId, int id, [FromBody] JsonPatchDocument<ProductFeatureForUpdateDto> patchDoc) {
            if(null == patchDoc) return BadRequest();

            var product = ProductsDataStore.Current.Products.FirstOrDefault(p => p.Id == productId);

            if(null == product) {
                return NotFound();
            }

            var productFeatureToPatch = product.ProductFeatures.FirstOrDefault(f => f.Id == id);

            if(null == productFeatureToPatch) {
                return NotFound();
            }

            var productFeaturePatch = new ProductFeatureForUpdateDto() {
                Name = productFeatureToPatch.Name,
                Description = productFeatureToPatch.Description
            };

            patchDoc.ApplyTo(productFeaturePatch, ModelState);

            if(!ModelState.IsValid) return BadRequest(ModelState);

            //This could not be done using the patch document
            if(productFeaturePatch.Name == productFeaturePatch.Description) {
                ModelState.AddModelError("Description", "The description must be different to name");
            }

            //This has to be run after the patch document was validated and attempted
            TryValidateModel(productFeaturePatch);

            if(!ModelState.IsValid) return BadRequest(ModelState);

            productFeatureToPatch.Name = productFeaturePatch.Name;
            productFeatureToPatch.Description = productFeaturePatch.Description;

            return NoContent();
        }
    }
}