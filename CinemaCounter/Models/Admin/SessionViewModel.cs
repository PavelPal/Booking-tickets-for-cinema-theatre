using System.Collections.Generic;
using System.Web.Mvc;
using CinemaCounter.Models.Entities;

namespace CinemaCounter.Models.Admin
{
    public class SessionViewModel
    {
        public SessionViewModel()
        {
            Scenes = new List<SelectListItem>();
            Cinemas = new List<SelectListItem>();
        }

        public List<SelectListItem> Scenes { get; set; }
        public List<SelectListItem> Cinemas { get; set; }
        public Session Session { get; set; }
    }
}