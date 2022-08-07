using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebTicketBooking.DAL.Models;
using System.Security.Claims;

namespace WebTicketBooking.Models.Account
{
    public class UpdateUserNameModel
    {
        [Required(ErrorMessage = "Username not specified")]
        public string NewUserName { get; set; }
    }
}
