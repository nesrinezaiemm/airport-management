using AM.APPCORE.domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Ticket
    {
        public double Price { get; set; }
        public string Siege { get; set; }
        public bool Vip { get; set; }
        [ForeignKey("flight")]
        public int FlightFK {get; set;}
        public Flight flight { get; set; }
        [ForeignKey("passenger")]
        public string PassengerFK { get; set; }
        public Passenger passenger { get; set; }
       

    }
}
