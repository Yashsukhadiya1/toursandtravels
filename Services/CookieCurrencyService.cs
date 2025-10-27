using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace toursandtravels.Services
{
	public class CookieCurrencyService : ICurrencyService
	{
		private const string CookieName = "currency";
		private static readonly Dictionary<string, decimal> RateFromInr = new()
		{
			{ "INR", 1m },
			{ "USD", 0.012m },
			{ "EUR", 0.011m }
		};

		public string GetCurrency(HttpContext httpContext)
		{
			return httpContext.Request.Cookies.TryGetValue(CookieName, out var c) ? c : "INR";
		}

		public void SetCurrency(HttpContext httpContext, string currencyCode)
		{
			if (!RateFromInr.ContainsKey(currencyCode)) currencyCode = "INR";
			httpContext.Response.Cookies.Append(CookieName, currencyCode, new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });
		}

		public decimal ConvertFromInr(decimal inrAmount, string currencyCode)
		{
			var rate = RateFromInr.TryGetValue(currencyCode, out var r) ? r : 1m;
			return Math.Round(inrAmount * rate, 2);
		}

		public string Format(decimal inrAmount, string currencyCode)
		{
			var amount = ConvertFromInr(inrAmount, currencyCode);
			var culture = currencyCode switch
			{
				"USD" => new CultureInfo("en-US"),
				"EUR" => new CultureInfo("fr-FR"),
				_ => new CultureInfo("en-IN")
			};
			return string.Format(culture, "{0:C}", amount);
		}
	}
}


