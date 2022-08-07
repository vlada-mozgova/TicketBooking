using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTicketBooking.DAL.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        [Required]
        public int? RoleId { get; set; }
        public Role RoleName { get; set; }
        public List<Ticket> ticketlist { get; set; }
        public User()
        {
            ticketlist = new List<Ticket>();
        }
    }
}
