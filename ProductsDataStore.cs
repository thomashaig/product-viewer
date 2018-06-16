using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using product_viewer.Models;

namespace product_viewer {
    public class ProductsDataStore {

        public static ProductsDataStore Current { get; } = new ProductsDataStore();
        public List<ProductDto> Products { get; set; }

        public ProductsDataStore() {
            //dummy data

            Products = new List<ProductDto>() {
                new ProductDto() { Id=1, Name="Product 1", Description="Our first and best product" },
                new ProductDto { Id=2, Name="Product 2", Description="The second fiddle" }
            };
        }
    }
}