using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KeysOnboardingProject2.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Display(Name ="Product Name")]
        [Required(ErrorMessage ="Product name is required")]
        [RegularExpression(@"^[a-zA-Z0-9'' ']+$", ErrorMessage ="Special charecters are not allowed")]
        public string Name { get; set; }
        [Display(Name ="Product Price")]
        [Required(ErrorMessage ="Product price is required")]
        public decimal Price { get; set; }

        public List<ProductSold> ProductSolds { get; set; }
    }
}