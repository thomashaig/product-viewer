using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace product_viewer.Models {
    public class ProductDto {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int NumberOfFeatures { get
            {
                return ProductFeatures.Count;
            }
        }

        //Uses new auto initialiser
        public ICollection<ProductFeatureDto> ProductFeatures { get; set; } = new List<ProductFeatureDto>();
    }
} 