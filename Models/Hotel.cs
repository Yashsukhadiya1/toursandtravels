namespace toursandtravels.Models
{
	public class Hotel
	{
		public int Id { get; set; }
		public string City { get; set; } = string.Empty;
		public string Name { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
		public decimal PricePerNight { get; set; }
		public int Stars { get; set; } = 3;
		public string ImageUrl { get; set; } = string.Empty;
		public int AvailableRooms { get; set; } = 5;
		public bool FreeBreakfast { get; set; } = true;
	}
}

