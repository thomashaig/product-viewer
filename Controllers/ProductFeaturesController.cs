using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using product_viewer.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;
using product_viewer.Services;
using product_viewer.Entities;
using AutoMapper;

namespace product_viewer.Controllers {
    [Route("api/products")]
    public class ProductFeaturesController : Controller {

        private ILogger<ProductFeaturesController> _logger;
        private IMailService _mailService;
        private IProductInfoRepository _productInfoRepository;

        public ProductFeaturesController(ILogger<ProductFeaturesController> logger, IProductInfoRepository productInfoRespository) {
            _logger = logger;
            _productInfoRepository = productInfoRespository;
        }

        [HttpGet("{productId}/productFeatures")]
        public IActionResult GetProductFeatures(int productId) {
            try {
                // Find Parent Product
                if(!_productInfoRepository.ProductExists(productId)) {
                    return NotFound();
                }

                var productFeatures = _productInfoRepository.GetProductFeatures(productId);

                var productFeaturesResult = Mapper.Map<IEnumerable<ProductFeatureDto>>(productFeatures);

                return Ok(productFeaturesResult);
            }
            catch(Exception) {
                _logger.LogCritical($"Exception while getting features for {productId}");
                return StatusCode(500, "Error occured while handling request");
            }
        }

        [HttpGet("{productId}/productFeatures/{id}", Name = "GetProductFeature")]
        public IActionResult GetProductFeature(int productId, int id) {
             // Find Parent Product
            // Find Parent Product
                if(!_productInfoRepository.ProductExists(productId)) {
                    return NotFound();
                }

                var feature = _productInfoRepository.GetProductFeature(productId, id);

                if(null == feature) {
                    return NotFound();
                }

                return Ok(Mapper.Map<ProductFeatureDto>(feature)); 
        }

        [HttpPost("{productId}/productFeatures")]
        public IActionResult CreateProductFeature(int productId, [FromBody] ProductFeatureForCreationDto productFeature) {
            if(null == productFeature) return BadRequest();

            //Description and name can not be the same (for some reason)
            if(productFeature.Name == productFeature.Description) {
                ModelState.AddModelError("Description", "The description must be different to name");
            }

            if(!ModelState.IsValid) return BadRequest(ModelState);

            if(!_productInfoRepository.ProductExists(productId)) {
                return NotFound();
            }

            var newProductFeature = Mapper.Map<Entities.ProductFeature>(productFeature);

            _productInfoRepository.AddFeatureForProduct(productId, newProductFeature);

            if(!_productInfoRepository.Save()) {
                return StatusCode(500, "Failed to save");
            }

            var newProductFeatureReturn = Mapper.Map<Models.ProductFeatureDto>(newProductFeature);

            //Note the returned productId is the same as the one that was passed in
            return CreatedAtRoute("GetProductFeature", new { productid = productId, id = newProductFeature.Id}, newProductFeatureReturn);
        }

        [HttpPut("{productId}/productFeatures/{id}")]
        public IActionResult UpdateProductFeature(int productId, int id, [FromBody] ProductFeatureForUpdateDto productFeature) {

            if(null == productFeature) return BadRequest();

            //Description and name can not be the same (for some reason)
            if(productFeature.Name == productFeature.Description) {
                ModelState.AddModelError("Description", "The description must be different to name");
            }

            if(!ModelState.IsValid) return BadRequest(ModelState);

            if(!_productInfoRepository.ProductExists(productId)) {
                return NotFound();
            }

            var productFeatureToPut = _productInfoRepository.GetProductFeature(productId, id);


            if(null == productFeatureToPut) return NotFound();

            Mapper.Map(productFeature, productFeatureToPut);

            
            if (!_productInfoRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }

        [HttpPatch("{productId}/productFeatures/{id}")]
        public IActionResult PartialUpdateProductFeature(int productId, int id, [FromBody] JsonPatchDocument<ProductFeatureForUpdateDto> patchDoc) {
            if(null == patchDoc) return BadRequest();

            if(!_productInfoRepository.ProductExists(productId)) {
                return NotFound();
            }

            var productFeatureEntity = _productInfoRepository.GetProductFeature(productId, id);

            if(null == productFeatureEntity) return NotFound();

            var productFeaturePatch = Mapper.Map<ProductFeatureForUpdateDto>(productFeatureEntity);
        
            patchDoc.ApplyTo(productFeaturePatch, ModelState);

            if(!ModelState.IsValid) return BadRequest(ModelState);

            //This could not be done using the patch document
            if(productFeaturePatch.Name == productFeaturePatch.Description) {
                ModelState.AddModelError("Description", "The description must be different to name");
            }

            //This has to be run after the patch document was validated and attempted
            TryValidateModel(productFeaturePatch);

            if(!ModelState.IsValid) return BadRequest(ModelState);

            Mapper.Map(productFeaturePatch, productFeatureEntity);

            if (!_productInfoRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }

        [HttpDelete("{productId}/productFeatures/{id}")]
        public IActionResult DeleteProductFeature(int productId, int id) {
            if(!_productInfoRepository.ProductExists(productId)) {
                return NotFound();
            }

            var productFeatureToDelete = _productInfoRepository.GetProductFeature(productId, id);

            if(null == productFeatureToDelete) {
                return NotFound();
            }

            _productInfoRepository.DeleteFeature(productFeatureToDelete);


            if (!_productInfoRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }
    }
}