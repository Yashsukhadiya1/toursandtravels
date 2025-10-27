using toursandtravels.Models;

namespace toursandtravels.Services
{
	public class InMemoryTourService : ITourService
	{
		private readonly List<Tour> _tours = new()
		{
			new Tour
			{
				Id = 1,
				Title = "Golden Triangle: Delhi, Agra & Jaipur",
				Destination = "India",
				Summary = "Experience India's iconic cities with Taj Mahal and forts.",
				Highlights = new [] { "Taj Mahal sunrise", "Amber Fort", "Old Delhi tour" },
				DurationDays = 6,
				PricePerPerson = 24999,
				HeroImageUrl = "/images/tour1.jpg"
			},
			new Tour
			{
				Id = 2,
				Title = "Goa Beaches Getaway",
				Destination = "Goa, India",
				Summary = "Relaxing beach holiday with water sports and nightlife.",
				Highlights = new [] { "Calangute Beach", "Dudhsagar Falls", "Parasailing" },
				DurationDays = 4,
				PricePerPerson = 12999,
				HeroImageUrl = "/images/tour2.jpg"
			},
			new Tour
			{
				Id = 3,
				Title = "Kashmir Paradise Tour",
				Destination = "Srinagar, Gulmarg, Pahalgam",
				Summary = "Houseboat stay, gondola rides, and alpine meadows.",
				Highlights = new [] { "Dal Lake shikara", "Gulmarg gondola", "Betaab Valley" },
				DurationDays = 5,
				PricePerPerson = 21999,
				HeroImageUrl = "/images/tour3.jpg"
			}
		};

		public IEnumerable<Tour> GetAll() => _tours;
		public Tour? GetById(int id) => _tours.FirstOrDefault(t => t.Id == id);
	}
}


