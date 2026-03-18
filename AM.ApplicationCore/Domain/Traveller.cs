using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.APPCORE.domain
{
    public class Traveller : Passenger
    {
        public string Nationality { get; set; }
        public string HealthInformation { get; set; }
        //Tp2 : 2.b
        public override void PassengerType()
        {
            //base kaynha super fl java (tekhou l msg mtaa l parent as it is)
            base.PassengerType();
            Console.WriteLine("I am a traveller");
        }
    }
}
