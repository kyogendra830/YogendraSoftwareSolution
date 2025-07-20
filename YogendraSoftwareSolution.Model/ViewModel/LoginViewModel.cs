using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogendraSoftwareSolution.Model.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter email id")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }
        public string Forgotpassword { get; set; }
    }
}
