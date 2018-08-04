using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KeysOnboardingProject2.Models
{
    public class Store
    {
        public int Id { get; set; }

        [Display(Name ="Store Name")]
        [Required(ErrorMessage ="Store name is required")]
        public string Name { get; set; }

        [Display(Name ="Store Address")]
        public String Address { get; set; }

        public List<ProductSold> ProductSolds { get; set; }
    }
}