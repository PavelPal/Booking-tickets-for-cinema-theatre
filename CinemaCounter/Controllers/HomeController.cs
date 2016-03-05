using System.Web.Mvc;
using CinemaCounter.Models.Home;

namespace CinemaCounter.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = _homeService.Show();
            return View(model);
        }

        [HttpGet]
        public ActionResult LoadMoreCinemas(int skip)
        {
            return Json(_homeService.LoadMoreCinemas(skip), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult LoadMoreSessions(int skip)
        {
            return Json(_homeService.LoadMoreSessions(skip), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
    }
}