using System.ComponentModel.DataAnnotations;

namespace toursandtravels.Models
{
	public class Booking
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public int TourId { get; set; }
		[Required]
		public string FullName { get; set; } = string.Empty;
		[Required, EmailAddress]
		public string Email { get; set; } = string.Empty;
		[Required]
		public DateTime StartDate { get; set; } = DateTime.UtcNow.Date.AddDays(7);
		[Range(1, 20)]
		public int Travellers { get; set; } = 2;
		public decimal TotalAmount { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public string Status { get; set; } = "Pending";
	}
}


