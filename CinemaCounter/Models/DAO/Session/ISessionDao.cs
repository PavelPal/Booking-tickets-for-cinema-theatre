using System.Collections.Generic;

namespace CinemaCounter.Models.DAO.Session
{
    public interface ISessionDao
    {
        void Add();
        void Edit();
        void Delete();
        Enities.Session Load(int id);
        List<Enities.Session> Load(int skip, int take);
    }
}