using Microsoft.AspNetCore.Mvc;

namespace toursandtravels.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Flights()
		{
			return View();
		}

		public IActionResult Hotels()
		{
			return View();
		}

		public IActionResult Results()
		{
			return View();
		}
	}
}


