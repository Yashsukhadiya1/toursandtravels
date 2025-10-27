using Microsoft.AspNetCore.Mvc;
using toursandtravels.Data;
using toursandtravels.Models;

namespace toursandtravels.Controllers
{
	public class AdminController : Controller
	{
		private readonly TravelDbContext _context;

		public AdminController(TravelDbContext context)
		{
			_context = context;
		}

		public IActionResult Bookings()
		{
			var bookings = _context.Bookings
				.OrderByDescending(b => b.CreatedAt)
				.ToList();

			var bookingViewModels = bookings.Select(b => new
			{
				Booking = b,
				Tour = _context.Tours.FirstOrDefault(t => t.Id == b.TourId)
			}).ToList();

			ViewBag.UnreadCount = _context.Notifications.Count(n => !n.IsRead);
			return View(bookingViewModels);
		}

		public IActionResult Notifications()
		{
			var notifications = _context.Notifications
				.OrderByDescending(n => n.CreatedAt)
				.ToList();
			
			return View(notifications);
		}

		[HttpPost]
		public IActionResult MarkNotificationRead([FromForm] int id)
		{
			var notification = _context.Notifications.FirstOrDefault(n => n.Id == id);
			if (notification != null)
			{
				notification.IsRead = true;
				_context.SaveChanges();
			}
			return Json(new { success = true });
		}

		[HttpPost]
		public IActionResult MarkAllNotificationsRead()
		{
			var unreadNotifications = _context.Notifications.Where(n => !n.IsRead).ToList();
			foreach (var notification in unreadNotifications)
			{
				notification.IsRead = true;
			}
			_context.SaveChanges();
			return Json(new { success = true, count = unreadNotifications.Count });
		}

		[HttpPost]
		public IActionResult UpdateBookingStatus([FromForm] Guid bookingId, [FromForm] string status)
		{
			var booking = _context.Bookings.FirstOrDefault(b => b.Id == bookingId);
			if (booking != null)
			{
				booking.Status = status;
				_context.SaveChanges();

				// Create notification for user
				var tour = _context.Tours.FirstOrDefault(t => t.Id == booking.TourId);
				var notification = new Notification
				{
					BookingId = bookingId,
					Message = $"Booking status updated: Your booking for '{tour?.Title}' is now {status}",
					CreatedAt = DateTime.UtcNow,
					IsRead = false
				};
				_context.Notifications.Add(notification);
				_context.SaveChanges();
			}
			return Json(new { success = true });
		}

		public int GetUnreadNotificationCount()
		{
			return _context.Notifications.Count(n => !n.IsRead);
		}
	}
}

