using System.Collections.Generic;

namespace CinemaCounter.Models.DAO.Cinema
{
    public interface ICinemaDao
    {
        void Add();
        void Edit();
        void Delete();
        Enities.Cinema Load(int id);
        List<Enities.Cinema> Load(int skip, int take);
    }
}