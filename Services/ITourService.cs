using toursandtravels.Models;

namespace toursandtravels.Services
{
	public interface ITourService
	{
		IEnumerable<Tour> GetAll();
		Tour? GetById(int id);
	}
}


