using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTicketBooking.Models.Account
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Invalid username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Invalid password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
