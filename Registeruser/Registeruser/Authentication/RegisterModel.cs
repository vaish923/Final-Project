using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Registeruser.Authentication
{
    public class RegisterModel
    {
        
        [Required(ErrorMessage = "User Name is required")]

        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "password is Required")]
        public string Password { get; set; }

       



    }
}
