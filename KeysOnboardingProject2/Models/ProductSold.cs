﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KeysOnboardingProject2.Models
{
    public class ProductSold
    {
        public virtual int Id { get; set; }
        public virtual int ProductId { get; set; }
        public virtual int CustomerId { get; set; }
        public virtual int StoreId { get; set; }
        [Display(Name = "Date Sold")]
        [Required(ErrorMessage = "Please input Sold Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public virtual DateTime DateSold { get; set; }

        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Store Store { get; set; }
    }
}