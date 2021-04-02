using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_Product_management_Project.Models
{
    public class mvcProduct
    {
        public int Id { get; set; }
        [Required]

        [StringLength(50)]
        public string Name { get; set; }
        [Required]

        public double? Price { get; set; }
        [Required]

        [StringLength(50)]
        public string Category { get; set; }

        public int? Quantity { get; set; }
        [Required]
        [Column("Short Description")]
        [StringLength(50)]
        public string Short_Description { get; set; }
        [Required]

        [Column("Long Description")]
        [StringLength(100)]
        public string Long_Description { get; set; }

        public string ImagePath { get; set; }

    }
    public class ProductDBContext : DbContext
    {
        public DbSet<mvcProduct> Products { get; set; }
    }
}