using toursandtravels.Data;
using toursandtravels.Models;

namespace toursandtravels.Services
{
	public class DatabaseTourService : ITourService
	{
		private readonly TravelDbContext _context;

		public DatabaseTourService(TravelDbContext context)
		{
			_context = context;
		}

		public IEnumerable<Tour> GetAll()
		{
			return _context.Tours.ToList();
		}

		public Tour? GetById(int id)
		{
			return _context.Tours.FirstOrDefault(t => t.Id == id);
		}
	}
}

