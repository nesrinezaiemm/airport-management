using AM.APPCORE.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interface
{
    internal interface IFlightMethod
    {
        public IList<DateTime> GetFlightDates(string destination);
        public void ShowFlightDetails(Plane plane);
        int ProgrammedFlightNumber(DateTime startDate);
        double DurationAverage(string destination);
        IEnumerable<Flight> OrderedDurationFlights();
        IEnumerable<Traveller> SeniorTravellers(Flight flight);
        void DestinationGroupedFlights();
    }
}