namespace toursandtravels.Models
{
	public class Flight
	{
		public int Id { get; set; }
		public string FromCity { get; set; } = string.Empty;
		public string ToCity { get; set; } = string.Empty;
		public DateTime Departure { get; set; }
		public DateTime? Return { get; set; }
		public string Airline { get; set; } = string.Empty;
		public string FlightNumber { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public int AvailableSeats { get; set; } = 10;
	}
}

