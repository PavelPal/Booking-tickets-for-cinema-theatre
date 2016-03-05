using System.Collections.Generic;
using CinemaCounter.Models.Entities;

namespace CinemaCounter.Models.Home
{
    public class IndexViewModel
    {
        public List<Entities.Cinema> Cinemas { get; set; }
        public List<Session> Sessions { get; set; }
    }
}