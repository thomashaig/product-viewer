using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace product_viewer.Entities {
    public class ProductInfoContext : DbContext {

        public ProductInfoContext(DbContextOptions<ProductInfoContext> options)
           : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
    }
} 