using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace product_viewer.Models {
    public class ProductFeatureForCreationDto {

        //Using data annotations
        [Required(ErrorMessage="You need to provide a name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
} 