using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace toursandtravels.Services
{
	public class RazorpayPaymentService : IPaymentService
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly string _keyId;
		private readonly string _keySecret;

		public RazorpayPaymentService(IHttpClientFactory httpClientFactory, IConfiguration config)
		{
			_httpClientFactory = httpClientFactory;
			_keyId = config["RAZORPAY_KEY_ID"] ?? "";
			_keySecret = config["RAZORPAY_KEY_SECRET"] ?? "";
		}

		public PaymentOrder CreateOrder(decimal amount, string currency, string receipt)
		{
			// Amount in subunits (paise for INR)
			var amountSub = (int)(amount * 100);
			var client = _httpClientFactory.CreateClient();
			var authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_keyId}:{_keySecret}"));
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);
			var payload = new
			{
				amount = amountSub,
				currency = currency,
				receipt = receipt,
				payment_capture = 1
			};
			var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
			var response = client.PostAsync("https://api.razorpay.com/v1/orders", content).GetAwaiter().GetResult();
			response.EnsureSuccessStatusCode();
			var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
			using var doc = JsonDocument.Parse(json);
			var orderId = doc.RootElement.GetProperty("id").GetString() ?? string.Empty;
			return new PaymentOrder(orderId, amount, currency, receipt);
		}
	}
}


