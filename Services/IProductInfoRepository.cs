using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using product_viewer.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;
using product_viewer.Entities;

namespace product_viewer.Services {
    public interface IProductInfoRepository {

        bool ProductExists(int productId);

        IEnumerable<Product> GetProducts();

        Product GetProduct(int productId, bool includeFeatures);

        IEnumerable<ProductFeature> GetProductFeatures(int productId);

        ProductFeature GetProductFeature(int productId, int featureId);

        void AddFeatureForProduct(int productId, ProductFeature productFeature);

        void DeleteFeature(ProductFeature feature);

        bool Save();
    }
}