using Microsoft.AspNetCore.Mvc;
using toursandtravels.Services;

namespace toursandtravels.Controllers
{
	public class CurrencyController : Controller
	{
		private readonly ICurrencyService _currencyService;
		public CurrencyController(ICurrencyService currencyService)
		{
			_currencyService = currencyService;
		}

		[HttpPost]
		public IActionResult Set(string code, string returnUrl = "/")
		{
			_currencyService.SetCurrency(HttpContext, code.ToUpperInvariant());
			return LocalRedirect(returnUrl);
		}
	}
}


