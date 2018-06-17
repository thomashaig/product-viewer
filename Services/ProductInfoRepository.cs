using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using product_viewer.Entities;
using Microsoft.EntityFrameworkCore;

namespace product_viewer.Services {
    public class ProductInfoRepository : IProductInfoRepository {

        private ProductInfoContext _context;

        public ProductInfoRepository(ProductInfoContext context) {
            _context = context;
        }

        public IEnumerable<Product> GetProducts() {
            return _context.Products.OrderBy(p => p.Name).ToList();
        }

        public Product GetProduct(int productId, bool includeFeatures) {
            if(includeFeatures) {
                return _context.Products.Include(p => p.ProductFeatures).Where(p => p.Id == productId).FirstOrDefault();
            }

            return _context.Products.Where(p => p.Id == productId).FirstOrDefault();
        }

        public IEnumerable<ProductFeature> GetProductFeatures(int productId) {
            return _context.ProductFeatures.Where(p => p.ProductId == productId).ToList();
        }

        public ProductFeature GetProductFeature(int productId, int featureId) {
            return _context.ProductFeatures.Where(p => p.ProductId == productId && p.Id == featureId).FirstOrDefault();
        }
    }
}