using System.Collections.Generic;

namespace CinemaCounter.Models.DAO.Cinema
{
    public interface ICinemaDao
    {
        void Add(Entities.Cinema cinema);
        void Edit(Entities.Cinema cinema);
        void Delete(int id);
        Entities.Cinema Load(int id);
        List<Entities.Cinema> Load(int skip, int take);
        int Count();
    }
}