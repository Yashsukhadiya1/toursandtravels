using toursandtravels.Models;

namespace toursandtravels.Services
{
	public interface IHotelService
	{
		IEnumerable<Hotel> Search(string city, DateTime checkin, DateTime checkout, int guests);
		Hotel? GetById(int id);
	}
	
	public class HotelService : IHotelService
	{
		private readonly Data.TravelDbContext _db;
		public HotelService(Data.TravelDbContext db) => _db = db;
		
		public IEnumerable<Hotel> Search(string city, DateTime checkin, DateTime checkout, int guests)
		{
			return _db.Hotels
				.Where(h => h.City.Contains(city, StringComparison.OrdinalIgnoreCase) &&
				           h.AvailableRooms > 0)
				.OrderBy(h => h.PricePerNight)
				.ToList();
		}
		
		public Hotel? GetById(int id) => _db.Hotels.Find(id);
	}
}

