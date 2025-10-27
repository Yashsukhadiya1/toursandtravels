using toursandtravels.Models;

namespace toursandtravels.Services
{
	public interface IReviewService
	{
		IEnumerable<Review> GetForTour(int tourId);
		void Add(Review review);
	}
}


