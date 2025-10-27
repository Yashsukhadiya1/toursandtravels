using toursandtravels.Data;
using toursandtravels.Models;

namespace toursandtravels.Services
{
	public class DatabaseBookingService : IBookingService
	{
		private readonly TravelDbContext _context;

		public DatabaseBookingService(TravelDbContext context)
		{
			_context = context;
		}

		public Booking Create(Booking booking)
		{
			_context.Bookings.Add(booking);
			_context.SaveChanges();

			// Create notification for admin
			var tour = _context.Tours.FirstOrDefault(t => t.Id == booking.TourId);
			var notification = new Notification
			{
				BookingId = booking.Id,
				Message = $"New booking: {booking.FullName} booked '{tour?.Title}' for {booking.Travellers} travellers on {booking.StartDate:yyyy-MM-dd}",
				CreatedAt = DateTime.UtcNow,
				IsRead = false
			};
			_context.Notifications.Add(notification);
			_context.SaveChanges();

			return booking;
		}

		public Booking? Get(Guid id)
		{
			return _context.Bookings.FirstOrDefault(b => b.Id == id);
		}

		public IEnumerable<Booking> GetAll()
		{
			return _context.Bookings.OrderByDescending(b => b.CreatedAt).ToList();
		}
	}
}

