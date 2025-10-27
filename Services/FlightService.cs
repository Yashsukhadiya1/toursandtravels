using toursandtravels.Models;

namespace toursandtravels.Services
{
	public interface IFlightService
	{
		IEnumerable<Flight> Search(string from, string to, DateTime depart, int travellers);
		Flight? GetById(int id);
	}
	
	public class FlightService : IFlightService
	{
		private readonly Data.TravelDbContext _db;
		public FlightService(Data.TravelDbContext db) => _db = db;
		
		public IEnumerable<Flight> Search(string from, string to, DateTime depart, int travellers)
		{
			return _db.Flights
				.Where(f => f.FromCity.Contains(from, StringComparison.OrdinalIgnoreCase) &&
				           f.ToCity.Contains(to, StringComparison.OrdinalIgnoreCase) &&
				           f.Departure.Date == depart.Date &&
				           f.AvailableSeats >= travellers)
				.OrderBy(f => f.Price)
				.ToList();
		}
		
		public Flight? GetById(int id) => _db.Flights.Find(id);
	}
}

