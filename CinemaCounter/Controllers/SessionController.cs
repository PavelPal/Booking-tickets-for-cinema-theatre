using System.Web.Mvc;

namespace CinemaCounter.Controllers
{
    public class SessionController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Session(int id)
        {
            return View();
        }
    }
}