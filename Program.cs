using Microsoft.EntityFrameworkCore;
using toursandtravels.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TravelDbContext>(o => 
	o.UseInMemoryDatabase("TravelDB"));
builder.Services.AddScoped<toursandtravels.Services.IFlightService, toursandtravels.Services.FlightService>();
builder.Services.AddScoped<toursandtravels.Services.IHotelService, toursandtravels.Services.HotelService>();
builder.Services.AddScoped<toursandtravels.Services.ITourService, toursandtravels.Services.DatabaseTourService>();
builder.Services.AddScoped<toursandtravels.Services.IBookingService, toursandtravels.Services.DatabaseBookingService>();
builder.Services.AddSingleton<toursandtravels.Services.IReviewService, toursandtravels.Services.InMemoryReviewService>();
builder.Services.AddSingleton<toursandtravels.Services.ICurrencyService, toursandtravels.Services.CookieCurrencyService>();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<toursandtravels.Services.IPaymentService, toursandtravels.Services.RazorpayPaymentService>();
builder.Services.AddLocalization();
builder.Services.AddSession();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

var supportedCultures = new[] { "en-IN", "en-US" };
var localizationOptions = new RequestLocalizationOptions()
	.SetDefaultCulture("en-IN")
	.AddSupportedCultures(supportedCultures)
	.AddSupportedUICultures(supportedCultures);
app.UseRequestLocalization(localizationOptions);

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

// Seed data on startup
using (var scope = app.Services.CreateScope())
{
	var db = scope.ServiceProvider.GetRequiredService<TravelDbContext>();
	db.Database.EnsureCreated();
	SeedData(db);
}

app.Run();

static void SeedData(TravelDbContext db)
{
	if (db.Flights.Any() || db.Hotels.Any() || db.Tours.Any()) return;

	db.Flights.AddRange(
		new toursandtravels.Models.Flight { FromCity = "Delhi", ToCity = "Mumbai", Departure = DateTime.UtcNow.AddDays(7), Airline = "IndiGo", FlightNumber = "6E 201", Price = 4299, AvailableSeats = 15 },
		new toursandtravels.Models.Flight { FromCity = "Mumbai", ToCity = "Goa", Departure = DateTime.UtcNow.AddDays(10), Airline = "SpiceJet", FlightNumber = "SG 425", Price = 2999, AvailableSeats = 20 },
		new toursandtravels.Models.Flight { FromCity = "Delhi", ToCity = "Bangalore", Departure = DateTime.UtcNow.AddDays(5), Airline = "Air India", FlightNumber = "AI 560", Price = 5499, AvailableSeats = 12 },
		new toursandtravels.Models.Flight { FromCity = "Mumbai", ToCity = "Delhi", Departure = DateTime.UtcNow.AddDays(6), Airline = "Vistara", FlightNumber = "UK 845", Price = 5999, AvailableSeats = 18 },
		new toursandtravels.Models.Flight { FromCity = "Bangalore", ToCity = "Goa", Departure = DateTime.UtcNow.AddDays(8), Airline = "SpiceJet", FlightNumber = "SG 301", Price = 3499, AvailableSeats = 25 },
		new toursandtravels.Models.Flight { FromCity = "Delhi", ToCity = "Jaipur", Departure = DateTime.UtcNow.AddDays(3), Airline = "IndiGo", FlightNumber = "6E 5432", Price = 2499, AvailableSeats = 30 },
		new toursandtravels.Models.Flight { FromCity = "Mumbai", ToCity = "Pune", Departure = DateTime.UtcNow.AddDays(4), Airline = "IndiGo", FlightNumber = "6E 876", Price = 1599, AvailableSeats = 40 },
		new toursandtravels.Models.Flight { FromCity = "Delhi", ToCity = "Kolkata", Departure = DateTime.UtcNow.AddDays(9), Airline = "SpiceJet", FlightNumber = "SG 567", Price = 4799, AvailableSeats = 14 }
	);

	db.Hotels.AddRange(
		new toursandtravels.Models.Hotel { City = "Goa", Name = "Beach Resort Goa", Address = "Calangute Beach", PricePerNight = 2500, Stars = 4, AvailableRooms = 10, ImageUrl = "https://images.unsplash.com/photo-1602343168117-bb8ffe3e2e9f" },
		new toursandtravels.Models.Hotel { City = "Mumbai", Name = "Business Hotel Mumbai", Address = "Andheri", PricePerNight = 3200, Stars = 4, AvailableRooms = 8, ImageUrl = "https://images.unsplash.com/photo-1520250497591-112f2f40a3f4" },
		new toursandtravels.Models.Hotel { City = "Delhi", Name = "Conrad Delhi", Address = "Janpath", PricePerNight = 8500, Stars = 5, AvailableRooms = 15, FreeBreakfast = true, ImageUrl = "https://images.unsplash.com/photo-1566073771259-6a8506099945" },
		new toursandtravels.Models.Hotel { City = "Jaipur", Name = "Rambagh Palace", Address = "Bhawani Singh Road", PricePerNight = 12000, Stars = 5, AvailableRooms = 5, FreeBreakfast = true, ImageUrl = "https://images.unsplash.com/photo-1551882547-ff40c63fe5fa" },
		new toursandtravels.Models.Hotel { City = "Goa", Name = "Taj Exotica", Address = "Benaulim Beach", PricePerNight = 9500, Stars = 5, AvailableRooms = 12, FreeBreakfast = true, ImageUrl = "https://images.unsplash.com/photo-1571896349842-33c89424de2d" },
		new toursandtravels.Models.Hotel { City = "Bangalore", Name = "ITC Gardenia", Address = "Residency Road", PricePerNight = 7200, Stars = 5, AvailableRooms = 10, FreeBreakfast = true, ImageUrl = "https://images.unsplash.com/photo-1595576508898-5e8a68b61f7e" },
		new toursandtravels.Models.Hotel { City = "Mumbai", Name = "Oberoi Mumbai", Address = "Nariman Point", PricePerNight = 11000, Stars = 5, AvailableRooms = 8, FreeBreakfast = true, ImageUrl = "https://images.unsplash.com/photo-1566073771259-6a8506099945" }
	);

	db.Tours.AddRange(
		new toursandtravels.Models.Tour { Id = 1, Title = "Golden Triangle: Delhi, Agra & Jaipur", Destination = "India", Summary = "Experience India's iconic cities with Taj Mahal and forts.", Highlights = new[] { "Taj Mahal sunrise", "Amber Fort", "Old Delhi tour" }, DurationDays = 6, PricePerPerson = 24999, HeroImageUrl = "https://images.unsplash.com/photo-1564507592333-c60657eea523?w=800&h=600&fit=crop" },
		new toursandtravels.Models.Tour { Id = 2, Title = "Goa Beaches Getaway", Destination = "Goa, India", Summary = "Relaxing beach holiday with water sports and nightlife.", Highlights = new[] { "Calangute Beach", "Dudhsagar Falls", "Parasailing" }, DurationDays = 4, PricePerPerson = 12999, HeroImageUrl = "https://images.unsplash.com/photo-1544551763-46a013bb70d5?w=800&h=600&fit=crop" },
		new toursandtravels.Models.Tour { Id = 3, Title = "Kashmir Paradise Tour", Destination = "Srinagar, Gulmarg, Pahalgam", Summary = "Houseboat stay, gondola rides, and alpine meadows.", Highlights = new[] { "Dal Lake shikara", "Gulmarg gondola", "Betaab Valley" }, DurationDays = 5, PricePerPerson = 21999, HeroImageUrl = "https://images.unsplash.com/photo-1578662996442-48f60103fc96?w=800&h=600&fit=crop" },
		new toursandtravels.Models.Tour { Id = 4, Title = "Kerala Backwaters", Destination = "Kochi, Alleppey", Summary = "Serene backwaters, houseboat cruise through palm-fringed canals.", Highlights = new[] { "Houseboat stay", "Tea plantation", "Kathakali show" }, DurationDays = 5, PricePerPerson = 18999, HeroImageUrl = "https://images.unsplash.com/photo-1583417319070-4a69db38a482?w=800&h=600&fit=crop" },
		new toursandtravels.Models.Tour { Id = 5, Title = "Leh Ladakh Adventure", Destination = "Leh, Nubra Valley", Summary = "High-altitude desert, monasteries, and stunning landscapes.", Highlights = new[] { "Pangong Lake", "Khardung La pass", "Nubra Valley" }, DurationDays = 7, PricePerPerson = 34999, HeroImageUrl = "https://images.unsplash.com/photo-1506905925346-21bda4d32df4?w=800&h=600&fit=crop" }
	);

	db.SaveChanges();
}
