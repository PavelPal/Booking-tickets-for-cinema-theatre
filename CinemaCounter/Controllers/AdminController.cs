using System.Web.Mvc;
using CinemaCounter.Models.Admin;
using CinemaCounter.Models.Entities;

namespace CinemaCounter.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public ActionResult Statistic()
        {
            var model = _adminService.Inicialize();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddToTask(string body, string goal)
        {
            var requestModel = _adminService.AddTask(body, goal);
            return Json(requestModel);
        }

        [HttpPost]
        public ActionResult DeleteTask(int id)
        {
            _adminService.DeleteTask(id);
            return Json("Задание удалено");
        }

        [HttpPost]
        public ActionResult TogglePriority(int id)
        {
            _adminService.TogglePriority(id);
            return Json("Важность изменена");
        }

        [HttpPost]
        public ActionResult ToggleState(int id)
        {
            _adminService.ToggleState(id);
            return Json("Изменено состояние");
        }

        [HttpPost]
        public ActionResult ChangeTaskBody(int id, string body)
        {
            _adminService.ChangeTaskBody(id, body);
            return Json("Имя изменено");
        }

        public ActionResult Cinemas()
        {
            var model = _adminService.Show();
            return View(model);
        }

        [HttpGet]
        public ActionResult AddCinema()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCinema(Cinema cinema)
        {
            if (!ModelState.IsValid) return View(cinema);
            _adminService.AddCinemas(cinema);
            return RedirectToAction("Cinemas");
        }

        [HttpGet]
        public ActionResult DeleteCinema(int? id)
        {
            if (id == null) return RedirectToAction("Cinemas");
            return View(_adminService.LoadCinema(id.Value));
        }

        [HttpPost]
        public ActionResult DeleteCinema(int id)
        {
            _adminService.DeleteCinema(id);
            return RedirectToAction("Cinemas");
        }

        [HttpGet]
        public ActionResult EditCinema(int? id)
        {
            if (id == null) return RedirectToAction("Cinemas");
            return View(_adminService.GetCinema(id.Value));
        }

        [HttpPost]
        public ActionResult EditCinema(Cinema cinema)
        {
            if (!ModelState.IsValid) return View(cinema);
            _adminService.UpdateCinema(cinema);
            return RedirectToAction("Cinemas");
        }

        [HttpGet]
        public ActionResult LoadMoreCinemas(int skip)
        {
            return Json(_adminService.LoadMoreCinemas(skip), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Sessions(int skip = 0, int take = 20)
        {
            var model = _adminService.Scenes(skip, take);
            return View(model);
        }

        [HttpGet]
        public ActionResult AddScene()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddScene(Scene model)
        {
            if (ModelState.IsValid)
            {
                _adminService.AddScene(model);
            }
            return RedirectToAction("Sessions");
        }

        [HttpGet]
        public ActionResult AddSession()
        {
            var model = _adminService.InicializeForSessions();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddSession(string cinema, string scene, string date)
        {
            if (!ModelState.IsValid) return View();
            _adminService.AddSession(cinema, scene, date);
            return RedirectToAction("Sessions");
        }

        [HttpGet]
        public ActionResult EditSession(int? id)
        {
            if (id == null) return RedirectToAction("Sessions");
            var model = _adminService.InicializeForEditSessions((int) id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditSession(string cinema, string scene, Session session)
        {
            _adminService.EditSession(cinema, scene, session);
            return RedirectToAction("Sessions");
        }

        [HttpGet]
        public ActionResult EditScene(int? id)
        {
            if (id == null) return RedirectToAction("Sessions");
            var model = _adminService.LoadScene((int) id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditScene(Scene scene)
        {
            _adminService.EditScene(scene);
            return RedirectToAction("Sessions");
        }

        [HttpGet]
        public ActionResult DeleteSession(int? id)
        {
            if (id == null) return RedirectToAction("Sessions");
            return View(_adminService.GetSession(id.Value));
        }

        [HttpPost]
        public ActionResult DeleteSession(int id)
        {
            _adminService.DeleteSession(id);
            return RedirectToAction("Sessions");
        }

        [HttpGet]
        public ActionResult AddActor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddActor(Actor actor)
        {
            if (!ModelState.IsValid) return View(actor);
            _adminService.AddActor(actor);
            return RedirectToAction("Sessions");
        }

        [HttpGet]
        public ActionResult AddGenre()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddGenre(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _adminService.AddGenre(genre);
                return RedirectToAction("Sessions");
            }
            return View(genre);
        }

        [HttpGet]
        public ActionResult AddCompany()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCompany(Company company)
        {
            if (ModelState.IsValid)
            {
                _adminService.AddCompany(company);
                return RedirectToAction("Sessions");
            }
            return View(company);
        }

        [HttpGet]
        public ActionResult AddDirector()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDirector(Director director)
        {
            if (!ModelState.IsValid) return View(director);
            _adminService.AddDirector(director);
            return RedirectToAction("Sessions");
        }

        public ActionResult Tickets()
        {
            var model = _adminService.LoadTickets();
            return View(model);
        }
    }
}