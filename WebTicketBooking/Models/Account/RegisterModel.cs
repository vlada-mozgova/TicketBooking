using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTicketBooking.Models.Account
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Invalid username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Invalid email")]
        public string Email { get; set; }
        public string Code { get; set; }

        [Required(ErrorMessage = "Invalid password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Invalid password")]
        public string ConfirmPassword { get; set; }
    }
}
