using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTicketBooking.DAL.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        [Required]
        public string Origin { get; set; }
        [Required]
        public string Origin_name { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public string Destination_name { get; set; }
        [Required]
        public DateTime Departure_date { get; set; }
        [Required]
        public DateTime Arrival_date { get; set; }
        [Required]
        public string Carrier { get; set; }
        [Required]
        public int Stops { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Count { get; set; }
    }
}
