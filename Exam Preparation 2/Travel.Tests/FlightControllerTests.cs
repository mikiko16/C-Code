// REMOVE any "using" statements, which start with "Travel." BEFORE SUBMITTING

namespace Travel.Tests
{
	using NUnit.Framework;
    using Travel.Core.Controllers;
    using Travel.Entities;
    using Travel.Entities.Airplanes;
    using Travel.Entities.Contracts;
    using Travel.Entities.Items;

    [TestFixture]
    public class FlightControllerTests
    {
	    [Test]
	    public void Test1()
	    {
            IAirport airport = new Airport();
            FlightController flightController = new FlightController(airport);
            var airplane = new LightAirplane();
            var passenger = new Passenger("Pesho");
            airplane.AddPassenger(passenger);
            var bag = new Bag(passenger, new Item[] { new Colombian()});
            passenger.Bags.Add(bag);
            var trip = new Trip("Tuk", "Tam", airplane);
            airport.AddTrip(trip);
        }
    }
}
