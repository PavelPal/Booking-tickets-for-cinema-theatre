using System.Collections.Generic;
using CinemaCounter.Models.Entities;

namespace CinemaCounter.Models.Admin
{
    public class IndexViewModel
    {
        public int CinemasCount { get; set; }
        public int SessionsCount { get; set; }
        public int UsersCount { get; set; }
        public int ThicketsCount { get; set; }
        public List<Task> Tasks { get; set; }
    }
}