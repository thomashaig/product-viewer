using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using product_viewer.Entities;

namespace product_viewer {
    public static class ProductInfoExtensions {
        //The "this" describes that it extendes "ProductInfoContext"
        public static void EnsureSeedDataForContext(this ProductInfoContext context) {

            //If there are any products do not re-seed
            if(context.Products.Any()) {
                return;
            };
            
            //Seed data
            var products = new List<Product>() {
                new Product() { 
                    Name="Product 1", 
                    Description="Our first and best product", 
                    ProductFeatures = new List<ProductFeature>() {
                        new ProductFeature() {
                            Name = "Goes boing",
                            Description = "Makes an annoying sound"
                        },
                        new ProductFeature() {
                            Name = "Goes bang",
                            Description = "Another, but less annoying sound"
                        }
                    }
                },
                new Product { 
                    //Make sure you comment the ID's out!!!
                    Name="Product 2", 
                    Description="The second fiddle",
                    ProductFeatures = new List<ProductFeature>() {
                        new ProductFeature() {
                            Name = "Fiddle",
                            Description = "Actually can be used as a fiddle"
                        }
                    }
                }
                new Product { 
                    //Make sure you comment the ID's out!!!
                    Name="Product 3", 
                    Description="A third product"
                },
                new Product { 
                    //Make sure you comment the ID's out!!!
                    Name="Product 4", 
                    Description="The forth product in the range",
                    ProductFeatures = new List<ProductFeature>() {
                        new ProductFeature() {
                            Name = "Not many",
                            Description = "Only has one feature"
                        }
                    }
                }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
} 