﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace editroles.Model
{
    public class RegistrationView
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
        public string Email { get; set; }

        public string Role { get; set; }
    }
}