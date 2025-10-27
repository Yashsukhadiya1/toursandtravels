using toursandtravels.Models;

namespace toursandtravels.Services
{
	public class InMemoryReviewService : IReviewService
	{
		private readonly List<Review> _reviews = new();
		public IEnumerable<Review> GetForTour(int tourId) => _reviews.Where(r => r.TourId == tourId).OrderByDescending(r => r.CreatedAt);
		public void Add(Review review) => _reviews.Add(review);
	}
}


