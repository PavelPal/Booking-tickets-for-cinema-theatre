using System.Web.Mvc;
using CinemaCounter.Models.Entities;
using CinemaCounter.Models.Home;

namespace CinemaCounter.Controllers
{
    public class SessionController : Controller
    {
        private readonly IHomeService _homeService;

        public SessionController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        public ActionResult Index()
        {
            var model = _homeService.LoaSessions();
            return View(model);
        }

        public ActionResult Today()
        {
            var model = _homeService.LoadSessionsToday();
            return View(model);
        }

        public ActionResult Week()
        {
            var model = _homeService.LoadSessionsWeek();
            return View(model);
        }

        public ActionResult Month()
        {
            var model = _homeService.LoadSessionsMonth();
            return View(model);
        }

        public ActionResult Session(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            var model = _homeService.LoadSession(id.Value);
            return View(model);
        }

        public ActionResult Complete()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Book(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            var model = _homeService.InicializeForBooking(id.Value);
            return View(model);
        }

        [HttpPost]
        public ActionResult Book(Ticket ticket)
        {
            if (!ModelState.IsValid) return View(ticket);
            _homeService.Booking(ticket);
            return RedirectToAction("Complete");
        }
    }
}