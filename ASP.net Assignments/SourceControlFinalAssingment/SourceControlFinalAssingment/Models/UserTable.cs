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

        [StringLength(20, ErrorMessage ="User Name must be less then 20 characters")]
        [Required(ErrorMessage ="User Name is Required")]
        [DisplayName("User Name")]
        public string UserName { get; set; }
       
        [Required(ErrorMessage = "Password is Required")]
        [MinLength(6)]
        [DataType(DataType.Password)]
        [StringLength(100)]
        public string Password { get; set; }

        [Compare("Password")]
        [Required]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Range(13,100, ErrorMessage= "Age Must be between 13 and 100")]
        public int Age { get; set; }

        [StringLength(50)]
        public string ErrorMessage { get; set; }
    }
}
