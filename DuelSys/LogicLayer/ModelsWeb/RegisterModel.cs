using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LogicLayer
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Username is required")]
        [MinLength(5, ErrorMessage = "The minimum lenght is 5 symbols")]
        public string Username { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Age is required!")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "Email is not valid. It must have @ and to be ending .com/.nl/.bg etc.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be between 6 and 25 symbols")]
        [MaxLength(25, ErrorMessage = "Password must be between 6 and 25 symbols")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Passwords don't math")]
        public string RepeatPassword { get; set; }
    }
}
