using System.Collections.Generic;

namespace CinemaCounter.Models.DAO.Session
{
    public interface ISessionDao
    {
        void Add(Entities.Session session);
        void Edit(Entities.Session session);
        void Delete(int id);
        Entities.Session Load(int id);
        List<Entities.Session> Load(int skip, int take);
        List<Entities.Session> Load(int id, int skip, int take);
        List<Entities.Session> LoadToday(int skip, int take);
        List<Entities.Session> LoadWeek(int skip, int take);
        List<Entities.Session> LoadMonth(int skip, int take);
        int Count();
    }
}