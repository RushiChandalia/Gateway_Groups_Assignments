﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Web;

namespace MVC_Product_management_Project.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public string Short_Description { get; set; }

        public string Long_Description { get; set; }
    }
    public class ProductsDBContext : DbContext
    {
        public DbSet<Products> Products { get; set; }
    }
}