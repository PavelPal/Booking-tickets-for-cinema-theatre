using System.Collections.Generic;
using CinemaCounter.Models.Entities;

namespace CinemaCounter.Models.Cinema
{
    public interface ICinemaService
    {
        CinemaViewModel Show(int id);
        List<Session> LoadMoreSessions(int id, int skip);
    }
}