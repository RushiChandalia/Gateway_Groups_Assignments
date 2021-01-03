using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Product_management_Project.Models
{
    public class products
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public double? Price { get; set; }

        [StringLength(50)]
        public string Category { get; set; }

        public int? Quantity { get; set; }

        [Column("Short Description")]
        [StringLength(50)]
        public string Short_Description { get; set; }

        [Column("Long Description")]
        [StringLength(100)]
        public string Long_Description { get; set; }

        [Column("Small Image")]
        [StringLength(50)]
        public string Small_Image { get; set; }

        [Column("Large Image")]
        [StringLength(50)]
        public string Large_Image { get; set; }
    }
}