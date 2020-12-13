using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SourceControlAssignment1.Models
{
    public class user
    {   
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Characters are not allowed.")]
        [DisplayName("First Name")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$")]
        [DisplayName("Last Name")]
        public string Surname { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage ="Password should be more then 6 character")]
        public string Password { get; set; }
        [MaxLength(10)]
        public int PhoneNumber { get; set; }
        [MaxLength(30)]
        public string Address { get; set; }
        public int Age { get; set; }
    }
}