using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using product_viewer.Services;
using product_viewer.Models;


namespace product_viewer.Controllers {
    [Route("api/products")]
    public class ProductsController : Controller {

        private IProductInfoRepository _productInfoRepository;

        //Still takes in interface, not a concrete class
        public ProductsController(IProductInfoRepository productInfoRepository) {
            _productInfoRepository = productInfoRepository;
        }

        [HttpGet()]
        public IActionResult GetProducts() {
            var productEntities = _productInfoRepository.GetProducts();

            var results = new List<ProductNoFeaturesDto>();

            foreach(var productEntity in productEntities) 
            {
                results.Add(new ProductNoFeaturesDto{
                    Id = productEntity.Id,
                    Name = productEntity.Name,
                    Description = productEntity.Description
                });
            }

            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id, bool includeFeatures = false) {
            var product = _productInfoRepository.GetProduct(id, includeFeatures);

            if(null == product) {
                return NotFound();
            }

            if(includeFeatures) {
                var productResult = new ProductDto() {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description
                };

                foreach(var feature in product.ProductFeatures) {
                    productResult.ProductFeatures.Add(
                        new ProductFeatureDto() {
                            Id = feature.Id,
                            Name = feature.Name,
                            Description = feature.Description
                        }
                    );
                }

                return Ok(productResult);
            }

            var productNoFeatures = new ProductNoFeaturesDto() {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description
            }; 

            return Ok(productNoFeatures);
        }
    }
}