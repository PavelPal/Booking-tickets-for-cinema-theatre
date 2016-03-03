using System.Collections.Generic;

namespace CinemaCounter.Models.DAO.Director
{
    public interface IDirectorDao
    {
        void Add();
        void Edit();
        void Delete();
        Enities.Director Load(int id);
        List<Enities.Director> Load(int skip, int take);
    }
}