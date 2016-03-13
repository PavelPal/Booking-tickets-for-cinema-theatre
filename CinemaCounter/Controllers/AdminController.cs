using System.Web.Mvc;
using CinemaCounter.Models.Admin;

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

        public ActionResult AdminPanel()
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

        public ActionResult Cinemas()
        {
            return View();
        }

        public ActionResult LoadMoreCinemas(int skip)
        {
            var model = _adminService.LoadMoreCinemas(skip);
            return Json(model);
        }

        public ActionResult Scenes()
        {
            return View();
        }

        public ActionResult Sessions()
        {
            return View();
        }

        public ActionResult Tickets()
        {
            return View();
        }
    }
}