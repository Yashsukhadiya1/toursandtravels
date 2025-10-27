using Microsoft.AspNetCore.Mvc;
using toursandtravels.Models;
using toursandtravels.Services;

namespace toursandtravels.Controllers
{
	public class BookingController : Controller
	{
		private readonly ITourService _tourService;
		private readonly IBookingService _bookingService;

		public BookingController(ITourService tourService, IBookingService bookingService)
		{
			_tourService = tourService;
			_bookingService = bookingService;
		}

		[HttpGet]
		public IActionResult Create(int tourId)
		{
			var tour = _tourService.GetById(tourId);
			if (tour == null) return NotFound();
			var model = new Booking
			{
				TourId = tourId,
				Travellers = 2,
				StartDate = DateTime.UtcNow.Date.AddDays(7),
				TotalAmount = Math.Max(1, 2) * tour.PricePerPerson
			};
			return View(model);
		}

		[HttpPost]
		public IActionResult Create(Booking booking, string? action)
		{
			var tour = _tourService.GetById(booking.TourId);
			if (tour == null) return NotFound();
			if (!ModelState.IsValid) return View(booking);
			booking.TotalAmount = booking.Travellers * tour.PricePerPerson;
			var saved = _bookingService.Create(booking);
			if (string.Equals(action, "pay", System.StringComparison.OrdinalIgnoreCase))
			{
				return RedirectToAction("Start", "Payment", new { bookingId = saved.Id });
			}
			return RedirectToAction("Confirmation", new { id = saved.Id });
		}

		public IActionResult Confirmation(Guid id)
		{
			var booking = _bookingService.Get(id);
			if (booking == null) return NotFound();
			var tour = _tourService.GetById(booking.TourId);
			ViewBag.Tour = tour;
			return View(booking);
		}

		public IActionResult List()
		{
			var bookings = _bookingService.GetAll();
			var models = bookings.Select(b => new
			{
				Booking = b,
				Tour = _tourService.GetById(b.TourId)
			}).ToList();
			return View(models);
		}
	}
}


