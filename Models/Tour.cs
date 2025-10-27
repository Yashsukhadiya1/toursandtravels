namespace toursandtravels.Models
{
	public class Tour
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Destination { get; set; } = string.Empty;
		public string Summary { get; set; } = string.Empty;
		public string[] Highlights { get; set; } = System.Array.Empty<string>();
		public int DurationDays { get; set; }
		public decimal PricePerPerson { get; set; }
		public string HeroImageUrl { get; set; } = string.Empty;
	}
}


