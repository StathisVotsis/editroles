//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace editroles.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "This field cannot be empty")]
        public string Username { get; set; }

        [Required(ErrorMessage = "This field cannot be empty")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "This field cannot be empty")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "This field cannot be empty")]
        [DataType(DataType.Password)]
        public string Email { get; set; }

        public string Role { get; set; }
    }
}
