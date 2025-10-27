using Microsoft.EntityFrameworkCore;
using toursandtravels.Models;

namespace toursandtravels.Data
{
	public class TravelDbContext : DbContext
	{
		public TravelDbContext(DbContextOptions<TravelDbContext> options) : base(options) { }
		
		public DbSet<Flight> Flights { get; set; }
		public DbSet<Hotel> Hotels { get; set; }
		public DbSet<Tour> Tours { get; set; }
		public DbSet<Booking> Bookings { get; set; }
		public DbSet<Notification> Notifications { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Configure Tour entity for JSON storage of Highlights array
			modelBuilder.Entity<Tour>()
				.Property(t => t.Highlights)
				.HasConversion(
					v => string.Join("|||", v),
					v => v.Split("|||", StringSplitOptions.RemoveEmptyEntries),
					new Microsoft.EntityFrameworkCore.ChangeTracking.ValueComparer<string[]>(
						(c1, c2) => c1 != null && c2 != null && c1.SequenceEqual(c2),
						c => c != null ? c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())) : 0,
						c => c != null ? c.ToArray() : Array.Empty<string>()));

			// Configure decimal precision for all price fields
			modelBuilder.Entity<Booking>()
				.Property(b => b.TotalAmount)
				.HasPrecision(18, 2);

			modelBuilder.Entity<Flight>()
				.Property(f => f.Price)
				.HasPrecision(18, 2);

			modelBuilder.Entity<Hotel>()
				.Property(h => h.PricePerNight)
				.HasPrecision(18, 2);

			modelBuilder.Entity<Tour>()
				.Property(t => t.PricePerPerson)
				.HasPrecision(18, 2);

			// Configure Booking
			modelBuilder.Entity<Booking>()
				.HasKey(b => b.Id);
		}
	}
}

