using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace editroles.Model
{
    public class Login
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "This field cannot be empty")]
        public string Username { get; set; }

        [Required(ErrorMessage = "This field cannot be empty")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}