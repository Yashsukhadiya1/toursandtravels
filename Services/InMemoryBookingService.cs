using toursandtravels.Models;

namespace toursandtravels.Services
{
	public class InMemoryBookingService : IBookingService
	{
		private readonly Dictionary<Guid, Booking> _bookings = new();

		public Booking Create(Booking booking)
		{
			_bookings[booking.Id] = booking;
			return booking;
		}

		public Booking? Get(Guid id)
		{
			return _bookings.TryGetValue(id, out var b) ? b : null;
		}

		public IEnumerable<Booking> GetAll()
		{
			return _bookings.Values.OrderByDescending(b => b.StartDate);
		}
	}
}


