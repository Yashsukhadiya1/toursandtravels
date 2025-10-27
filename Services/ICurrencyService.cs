using Microsoft.AspNetCore.Http;

namespace toursandtravels.Services
{
	public interface ICurrencyService
	{
		string GetCurrency(HttpContext httpContext);
		void SetCurrency(HttpContext httpContext, string currencyCode);
		decimal ConvertFromInr(decimal inrAmount, string currencyCode);
		string Format(decimal inrAmount, string currencyCode);
	}
}


