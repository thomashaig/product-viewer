using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using product_viewer.Services;
using product_viewer.Models;
using AutoMapper;


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

            var results = Mapper.Map<IEnumerable<ProductNoFeaturesDto>>(productEntities);

            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id, bool includeFeatures = false) {
            var product = _productInfoRepository.GetProduct(id, includeFeatures);

            if(null == product) {
                return NotFound();
            }

            if(includeFeatures) {
                var productResult = Mapper.Map<ProductDto>(product);

                return Ok(productResult);
            }

            var productNoFeatures = Mapper.Map<ProductNoFeaturesDto>(product);

            return Ok(productNoFeatures);
        }
    }
}