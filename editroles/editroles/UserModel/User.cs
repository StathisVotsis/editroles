//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace editroles.UserModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
       
        public int Id { get; set; }
  
        public string Username { get; set; }
       
        public string Password { get; set; }
     
        public string Email { get; set; }

        public string Role { get; set; }
    }
}
