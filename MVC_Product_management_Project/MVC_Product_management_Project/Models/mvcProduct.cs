using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Product_management_Project.Models
{
    public class mvcProduct
    {   [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        [Required]

        public double? Price { get; set; }
        [Required]
        [StringLength(50)]
        public string Category { get; set; }
        [Required]
        public int? Quantity { get; set; }

        [Required]
        [Column("Short Description")]
        [DisplayName("Short Description")]
        [StringLength(50)]
        public string Short_Description { get; set; }

        [Column("Long Description")]
        [DisplayName("Long Description")]
        [StringLength(100)]
        public string Long_Description { get; set; }


    }
}