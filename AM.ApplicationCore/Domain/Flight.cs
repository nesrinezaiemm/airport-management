using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.APPCORE.domain
{
    public class Flight

    {
        public ICollection<Ticket> tickets { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public DateTime FlightDate { get; set; }
        public int EstimatedDuration { get; set; }

        public string Airline { get; set; }
        public int FlightId { get; set; }
        // Clé étrangère
        [ForeignKey("plane")]
        public int PlaneId { get; set; }
        public virtual Plane plane { get; set; }
        public virtual ICollection<Passenger> passengers { get; set; }
        public override string ToString()
        {
            return " Flight date:" + FlightDate
                + " ,Estimated duration :" + EstimatedDuration
                + " ,Destination:" + Destination
                + " ,Departure:" + Departure
                ;
        }
    }
}
