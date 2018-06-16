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
                new ProductDto() { 
                    Id=1, 
                    Name="Product 1", 
                    Description="Our first and best product", 
                    ProductFeatures = new List<ProductFeatureDto>() {
                        new ProductFeatureDto() {
                            Id = 1,
                            Name = "Goes boing",
                            Description = "Makes an annoying sound"
                        },
                        new ProductFeatureDto() {
                            Id = 2,
                            Name = "Goes bang",
                            Description = "Another, but less annoying sound"
                        }
                    }
                },
                new ProductDto { 
                    Id=2, 
                    Name="Product 2", 
                    Description="The second fiddle",
                    ProductFeatures = new List<ProductFeatureDto>() {
                        new ProductFeatureDto() {
                            Id = 1,
                            Name = "Fiddle",
                            Description = "Actually can be used as a fiddle"
                        }
                    }
                }
            };
        }
    }
}