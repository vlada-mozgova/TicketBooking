using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTicketBooking.Models.Account
{
    public class ApproveModel
    {
        [Required(ErrorMessage = "Ivalid code")]
        public string Code { get; set; }
    }
}
