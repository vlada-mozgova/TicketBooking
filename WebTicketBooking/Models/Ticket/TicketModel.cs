using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTicketBooking.Models.Ticket
{
    public class TicketModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Origin not specified")]
        public string Origin { get; set; }

        [Required(ErrorMessage = "Name of origin not specified")]
        public string Origin_name { get; set; }

        [Required(ErrorMessage = "Destination not specified")]
        public string Destination { get; set; }
        
        [Required(ErrorMessage = "Name of destination not specified")]
        public string Destination_name { get; set; }
        
        [Required(ErrorMessage = "Departure date not specified")]
        [DataType(DataType.DateTime)]
        public DateTime Departure_date { get; set; }
        
        [Required(ErrorMessage = "Arrival date not specified")]
        [DataType(DataType.DateTime)]
        public DateTime Arrival_date { get; set; }
        
        [Required(ErrorMessage = "Name of carrier not specified")]
        public string Carrier { get; set; }
        
        [Required(ErrorMessage = "Number of stops not specified")]
        public int Stops { get; set; }
        
        [Required(ErrorMessage = "Price not specified")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Count of available tickets not specified")]
        public int Count { get; set; }
    }
}
