namespace Travel.Entities
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Contracts;
	
	public class Airport : IAirport
	{
		private List<IBag> checkedBags;
		private List<IBag> confiscatedBags;
		private List<ITrip> trips;
		private List<IPassenger> people;

        public Airport()
        {
            this.checkedBags = new List<IBag>();
            this.confiscatedBags = new List<IBag>();
            this.trips = new List<ITrip>();
            this.people = new List<IPassenger>();
        }

        public IReadOnlyCollection<IBag> CheckedInBags => this.checkedBags;

        public IReadOnlyCollection<IBag> ConfiscatedBags => this.confiscatedBags;

        public IReadOnlyCollection<IPassenger> Passengers => this.people;

        public IReadOnlyCollection<ITrip> Trips => this.trips;

        public IPassenger GetPassenger(string username) => this.people.Find(x => x.Username == username);

		public ITrip GetTrip(string id) => this.trips.Find(x => x.Id == id);

		public void AddPassenger(IPassenger passenger) => this.people.Add(passenger);

		public void AddTrip(ITrip trip) => this.trips.Add(trip);

		public void AddCheckedBag(IBag bag) => this.checkedBags.Add(bag);

		public void AddConfiscatedBag(IBag bag) => this.confiscatedBags.Add(bag);
	}
}