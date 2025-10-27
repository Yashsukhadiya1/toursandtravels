namespace toursandtravels.Services
{
	public record PaymentOrder(string OrderId, decimal Amount, string Currency, string Receipt);

	public interface IPaymentService
	{
		PaymentOrder CreateOrder(decimal amount, string currency, string receipt);
	}
}


