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

        public ProductsController(ProductInfoRepository productInfoRepository) {
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
            //return Ok(ProductsDataStore.Current.Products);
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