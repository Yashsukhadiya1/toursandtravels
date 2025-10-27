using Microsoft.AspNetCore.Mvc;
using toursandtravels.Models;
using toursandtravels.Services;

namespace toursandtravels.Controllers
{
	public class ToursController : Controller
	{
		private readonly ITourService _tourService;
		private readonly IReviewService _reviewService;
		public ToursController(ITourService tourService, IReviewService reviewService)
		{
			_tourService = tourService;
			_reviewService = reviewService;
		}

		public IActionResult Index()
		{
			var tours = _tourService.GetAll();
			return View(tours);
		}

		public IActionResult Details(int id)
		{
			var tour = _tourService.GetById(id);
			if (tour == null) return NotFound();
			ViewBag.MapQuery = System.Web.HttpUtility.UrlEncode(tour.Destination);
			ViewBag.Reviews = _reviewService.GetForTour(id);
			return View(tour);
		}

		[HttpPost]
		public IActionResult AddReview(int id, Review review)
		{
			var tour = _tourService.GetById(id);
			if (tour == null) return NotFound();
			review.TourId = id;
			if (!ModelState.IsValid)
			{
				ViewBag.MapQuery = System.Web.HttpUtility.UrlEncode(tour.Destination);
				ViewBag.Reviews = _reviewService.GetForTour(id);
				return View("Details", tour);
			}
			_reviewService.Add(review);
			return RedirectToAction("Details", new { id });
		}
	}
}


