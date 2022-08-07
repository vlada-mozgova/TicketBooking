using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTicketBooking.Models.Ticket
{
    public class UpdateTicketModel
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public string Origin_name { get; set; }
        public string Destination { get; set; }
        public string Destination_name { get; set; }
        public DateTime Departure_date { get; set; }
        public DateTime Arrival_date { get; set; }
        public string Carrier { get; set; }
        public int Stops { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }
}
