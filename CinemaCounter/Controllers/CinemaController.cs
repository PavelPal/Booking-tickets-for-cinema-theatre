using System.Web.Mvc;
using CinemaCounter.Models.Cinema;

namespace CinemaCounter.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ICinemaService _cinemaService;

        public CinemaController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        public ActionResult Cinema(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var model = _cinemaService.Show((int) id);
            if (model.Cinema == null)
            {
                return new HttpStatusCodeResult(404);
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult LoadMoreSessions(int id, int skip)
        {
            return Json(_cinemaService.LoadMoreSessions(id, skip), JsonRequestBehavior.AllowGet);
        }
    }
}