using System.Collections.Generic;

namespace CinemaCounter.Models.DAO.Director
{
    public interface IDirectorDao
    {
        void Add(Entities.Director director);
        void Edit(Entities.Director director);
        void Delete(int id);
        Entities.Director Load(int id);
        List<Entities.Director> Load(int skip, int take);
        int Count();
    }
}