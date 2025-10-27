using Microsoft.AspNetCore.Mvc;
using toursandtravels.Services;

namespace toursandtravels.Controllers
{
	public class WishlistController : Controller
	{
		private const string SessionKey = "wishlist";
		private readonly ITourService _tourService;
		public WishlistController(ITourService tourService)
		{
			_tourService = tourService;
		}

		public IActionResult Index()
		{
			var ids = GetWishlist();
			var tours = ids.Select(id => _tourService.GetById(id)).Where(t => t != null)!.ToList();
			return View(tours);
		}

		[HttpPost]
		public IActionResult Add(int id, string? returnUrl = null)
		{
			var ids = GetWishlist();
			if (!ids.Contains(id)) ids.Add(id);
			SaveWishlist(ids);
			return LocalRedirect(returnUrl ?? "/");
		}

		[HttpPost]
		public IActionResult Remove(int id, string? returnUrl = null)
		{
			var ids = GetWishlist();
			ids.Remove(id);
			SaveWishlist(ids);
			return LocalRedirect(returnUrl ?? "/");
		}

		private List<int> GetWishlist()
		{
			var json = HttpContext.Session.GetString(SessionKey);
			return string.IsNullOrWhiteSpace(json) ? new List<int>() : System.Text.Json.JsonSerializer.Deserialize<List<int>>(json) ?? new List<int>();
		}

		private void SaveWishlist(List<int> ids)
		{
			var json = System.Text.Json.JsonSerializer.Serialize(ids);
			HttpContext.Session.SetString(SessionKey, json);
		}
	}
}


