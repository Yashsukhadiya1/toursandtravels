using Microsoft.AspNetCore.Mvc;
using toursandtravels.Services;

namespace toursandtravels.Controllers
{
	public class PaymentController : Controller
	{
		private readonly IPaymentService _paymentService;
		private readonly IConfiguration _config;

		public PaymentController(IPaymentService paymentService, IConfiguration config)
		{
			_paymentService = paymentService;
			_config = config;
		}

		public IActionResult Start(Guid bookingId)
		{
			ViewBag.BookingId = bookingId;
			var amount = 1000m; // Fallback
			var currency = "INR";
			var order = _paymentService.CreateOrder(amount, currency, $"rcpt_{bookingId}");
			ViewBag.OrderId = order.OrderId;
			ViewBag.Currency = order.Currency;
			ViewBag.Amount = order.Amount;
			ViewBag.RazorpayKey = _config["RAZORPAY_KEY_ID"] ?? "";
			return View();
		}

		[HttpPost]
		public IActionResult Complete(Guid bookingId)
		{
			TempData["Success"] = "Payment authorized (stub). Confirmation email sent (stub).";
			return RedirectToAction("Confirmation", "Booking", new { id = bookingId });
		}
	}
}


