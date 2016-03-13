using System.Collections.Generic;
using CinemaCounter.Models.Entities;

namespace CinemaCounter.Models.Cinema
{
    public class CinemaViewModel
    {
        public Entities.Cinema Cinema { get; set; }
        public List<Session> Sessions { get; set; }
    }
}