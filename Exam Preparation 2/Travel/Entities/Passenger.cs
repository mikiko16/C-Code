namespace Travel.Entities
{
	using System.Collections.Generic;
	using Contracts;

	public class Passenger : IPassenger
	{
        private List<IBag> bags;

		public Passenger(string username)
		{
			this.Username = username;

			this.bags = new List<IBag>();
		}

		public string Username { get; }

        IList<IBag> IPassenger.Bags => this.bags;
    }
}