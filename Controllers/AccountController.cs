using Microsoft.AspNetCore.Mvc;

namespace toursandtravels.Controllers
{
	public class AccountController : Controller
	{
		private const string SessionUser = "user_name";

		[HttpGet]
		public IActionResult Login(string? returnUrl = null)
		{
			ViewBag.ReturnUrl = returnUrl ?? "/";
			return View();
		}

		[HttpPost]
		public IActionResult Login(string username, string? returnUrl = null)
		{
			if (string.IsNullOrWhiteSpace(username))
			{
				ModelState.AddModelError("username", "Username is required");
				return View();
			}
			HttpContext.Session.SetString(SessionUser, username.Trim());
			return LocalRedirect(returnUrl ?? "/");
		}

		public IActionResult Logout(string? returnUrl = null)
		{
			HttpContext.Session.Remove(SessionUser);
			return LocalRedirect(returnUrl ?? "/");
		}

		public static string? GetCurrentUser(HttpContext context)
		{
			return context.Session.GetString(SessionUser);
		}
	}
}


