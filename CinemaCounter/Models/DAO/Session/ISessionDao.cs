using System;
using System.Collections.Generic;

namespace CinemaCounter.Models.DAO.Session
{
    public interface ISessionDao
    {
        void Add(int cinemaId, int sceneId, DateTime date);
        void Edit(Entities.Session session);
        void Delete(int id);
        Entities.Session Load(int id);
        List<Entities.Session> Load(int skip, int take);
        List<Entities.Session> Load(int id, int skip, int take);
        List<Entities.Session> LoadToday();
        List<Entities.Session> LoadWeek();
        List<Entities.Session> LoadMonth();
        int Count();
    }
}