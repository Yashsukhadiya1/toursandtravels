using toursandtravels.Models;

namespace toursandtravels.Services
{
	public interface IBookingService
	{
		Booking Create(Booking booking);
		Booking? Get(Guid id);
		IEnumerable<Booking> GetAll();
	}
}


