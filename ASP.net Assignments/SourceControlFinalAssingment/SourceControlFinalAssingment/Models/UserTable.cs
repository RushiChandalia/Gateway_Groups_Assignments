namespace SourceControlFinalAssingment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserTable")]
    public partial class UserTable
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(50)]
        [DisplayName("User Name")]
        [Required(ErrorMessage ="User Name cant be empty")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password cant be empty")]
        [DataType(DataType.Password)]
        [StringLength(100)]
        public string Password { get; set; }
       
    }
}
