namespace productwebapi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {   [Key]
        public int Id { get; set; }
        [Required]

        [StringLength(50)]
        public string Name { get; set; }
        [Required]

        public double? Price { get; set; }
        [Required]

        [StringLength(50)]
        public string Category { get; set; }
        [Required]

        public int? Quantity { get; set; }
        [Required]
        [DisplayName ("Short Description")]
        [Column("Short Description")]
        [StringLength(50)]
        public string Short_Description { get; set; }
        [Required]
        [DisplayName("Long Description")]

        [Column("Long Description")]
        [StringLength(100)]
        public string Long_Description { get; set; }

        public string ImagePath { get; set; }
    }
}
