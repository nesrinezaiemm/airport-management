// See https://aka.ms/new-console-template for more information


using AM.APPCORE.domain;
using AM.APPCORE.Service;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.service;
using AM.ApplicationCore.Service;
using AM.INFRASTRUCTURE;
using System.Collections.Generic;
using System.Numerics;
//pass.PassengerType();
/*Staff s=new Staff();
s.PassengerType();*/
FlightMethod fm = new FlightMethod();
fm.Flights = TestData.listFlights;
foreach (var item in fm.GetFlightDates("Paris"))
{
    Console.WriteLine(item);

}
fm.GetFlights("Destination", "Paris");
//Plane P2 = new Plane(PlaneType Airbus);
//fm.ShowFlightDetails(P2);

fm.ShowFlightDetails(TestData.BoingPlane);
// Initialisation du service

fm.Flights = TestData.listFlights;

Console.WriteLine("Question 4: DurationAverage");

// Test de la moyenne de durée pour Paris
double avgParis = fm.DurationAverage("Paris");
Console.WriteLine($"Moyenne de durée des vols vers Paris: {avgParis} minutes");

double avgMadrid = fm.DurationAverage("Madrid");
Console.WriteLine($"Moyenne de durée des vols vers Madrid: {avgMadrid} minutes");


Console.WriteLine("Question 5: OrderedDurationFlights");

// Test des vols ordonnés par durée
var orderedFlights = fm.OrderedDurationFlights();
Console.WriteLine("Vols ordonnés du plus long au plus court:");
foreach (var flight in orderedFlights)
{
    Console.WriteLine($"Destination: {flight.Destination}, Durée: {flight.EstimatedDuration} minutes, Date: {flight.FlightDate}");
}

Console.WriteLine("Question 6: SeniorTravellers");

// Test des 3 voyageurs les plus âgés du flight1
var seniorTravellers = fm.SeniorTravellers(TestData.flight1);
Console.WriteLine("Les 3 Travellers les plus âgés du flight1:");
foreach (var traveller in seniorTravellers)
{
    Console.WriteLine($"{traveller.FirstName} {traveller.LastName}, Né le: {traveller.BirthDate:dd/MM/yyyy}");
}

Console.WriteLine("Question 7: DestinationGroupedFlights");

// Test des vols groupés par destination
fm.DestinationGroupedFlights();
Passenger p = new Passenger
{
    FirstName = "nesrine",
    LastName = "zaiem",
    EmailAddress = "nesrinezaiem@esprit.tn",
};
PassengerExtension.UpperFullName(p);
Console.WriteLine($"Your name is {p. FirstName} {p.LastName}");
AMCONTEXT db = new AMCONTEXT();
//db.Planes.Add(TestData.Airbusplane);
//db.Flights.Add(TestData.flight6);
//db.SaveChanges();

Console.WriteLine("Ajout avec success");
foreach (var p in db.Flights)
{
    Console.WriteLine(p.Destination);
}