using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace product_viewer.Models {
    public class ProductNoFeaturesDto {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
} 