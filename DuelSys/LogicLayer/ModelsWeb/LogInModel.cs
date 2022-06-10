using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LogicLayer
{
    public class LogInModel
    {
        [Required(ErrorMessage = "Username is required!")]
        [MinLength(5, ErrorMessage = "Username must be at least 5 characters!")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        [MinLength(6, ErrorMessage = "Pasword must be at least 6 characters!")]
        public string? Password { get; set; }
    }
}
