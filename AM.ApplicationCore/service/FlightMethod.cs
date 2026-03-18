using AM.APPCORE.domain;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Service
{
    
    public class FlightMethod : IFlightMethod
    {
        public Action<Plane> FlightDetailsDel;
        public Func<string, double> DurationAverageDel;
        public List<Flight> Flights { get; set; }
        public FlightMethod()
        {
            FlightDetailsDel = ShowFlightDetails;
            DurationAverageDel = DurationAverage;
        }
        public IList<DateTime> GetFlightDates(string destination)
        {
            var query = from item in Flights
                        where item.Destination == destination
                        select item.FlightDate;
            return query.ToList();
        }

        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    foreach (var flight in Flights)
                    {
                        if (flight.Destination == filterValue)
                        {
                            Console.WriteLine($"Flight to {flight.Destination} on {flight.FlightDate}");
                        }
                    }
                    break;
                case "Departure":
                    foreach (var flight in Flights)
                    {
                        if (flight.Departure == filterValue)
                        {
                            Console.WriteLine($"Flight from {flight.Departure} on {flight.FlightDate}");
                        }
                    }
                    break;
                case "FlightDate":
                    foreach (var flight in Flights)
                    {
                        if (flight.FlightDate.Date == DateTime.Parse(filterValue))
                        {
                            Console.WriteLine($"Flight to {flight.Destination} on {flight.FlightDate}");
                        }
                    }
                    break;
                case "EffectiveArrival":
                    DateTime arrivalFilter;
                    if (DateTime.TryParse(filterValue, out arrivalFilter))
                    {
                        foreach (var flight in Flights)
                        {
                            if (flight.EffectiveArrival.Date == arrivalFilter.Date)
                            {
                                Console.WriteLine($"Flight to {flight.Destination} arriving on {flight.EffectiveArrival}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format.");
                    }
                    break;
                case "EstimatedDuration":
                    int durationFilter;
                    if (int.TryParse(filterValue, out durationFilter))
                    {
                        foreach (var flight in Flights)
                        {
                            if (flight.EstimatedDuration == durationFilter)
                            {
                                Console.WriteLine($"Flight to {flight.Destination} with duration {flight.EstimatedDuration} minutes");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid duration format.");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid filter type.");
                    break;
            }
        }

        public void ShowFlightDetails(Plane plane)
        {
            //var query = from f in Flights
            //            where f.plane == plane
            //            select new { f.FlightDate, f.Destination };
            var query = Flights.Where(f => f.plane == plane).Select (e=> new { e.FlightDate, e.Destination });

            foreach (var item in query)
            {
                Console.WriteLine($"Flight to {item.Destination} on {item.FlightDate}");
            }
        }

        public void ShowFlightDetails(System.Numerics.Plane plane)
        {
            throw new NotImplementedException();
        }
        public int ProgrammedFlightNumber(DateTime startDate)
        {
            var query = from f in Flights
                        where  
                        DateTime.Compare(f.FlightDate, startDate) >0 &&(f.FlightDate - startDate).TotalDays <=7
                        //f.FlightDate >= startDate && f.FlightDate < startDate.AddDays(7)
                        select f;
            return query.Count();
        }


        // Question 4: DurationAverage
        public double DurationAverage(string destination)
        {
            //var query = from f in Flights
            //            where f.Destination == destination
            //            select f.EstimatedDuration;

            //if (query.Any())
            //{
            //    return query.Average();
            //}
            //return 0;
            return Flights.Where(f => f.Destination == destination).Average(f => f.EstimatedDuration);

        }
        // Question 5: OrderedDurationFlights
        public IEnumerable<Flight> OrderedDurationFlights()
        {
            //    var query = from f in Flights
            //                orderby f.EstimatedDuration descending
            //                select f;
            //    return query;
            //}
            return Flights.OrderByDescending(f => f.EstimatedDuration);
        }
        // Question 6: SeniorTravellers
        public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {
            //var query = from p in flight.passengers
            //            where p is Traveller
            //            orderby p.BirthDate ascending
            //            select p as Traveller;

            //return query.Take(3);
            return flight.passengers.OfType<Traveller>().OrderBy(p => p.BirthDate).Take(3);
        }

        // Question 7: DestinationGroupedFlights
        public void DestinationGroupedFlights()
        {
            //var query = from f in Flights
            //            group f by f.Destination;
            var query = Flights.GroupBy(f => f.Destination);
            foreach (var group in query)
            {
                Console.WriteLine($"Destination {group.Key}");
                foreach (var flight in group)
                {
                    Console.WriteLine($"Décollage : {flight.FlightDate:dd/MM/yyyy HH:mm:ss}");
                }
            }
        }
    }
}