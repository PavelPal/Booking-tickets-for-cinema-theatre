using System.Collections.Generic;
using CinemaCounter.Models.Entities;

namespace CinemaCounter.Models.Home
{
    public interface IHomeService
    {
        IndexViewModel Show();
        List<Entities.Cinema> LoadMoreCinemas(int skip);
        List<Session> LoadMoreSessions(int skip);
    }
}