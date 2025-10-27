using System.ComponentModel.DataAnnotations;

namespace toursandtravels.Models
{
	public class Review
	{
		public int TourId { get; set; }
		[Range(1,5)]
		public int Rating { get; set; }
		[Required]
		public string Author { get; set; } = string.Empty;
		[Required]
		public string Comment { get; set; } = string.Empty;
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	}
}


