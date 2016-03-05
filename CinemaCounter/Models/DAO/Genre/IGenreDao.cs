using System.Collections.Generic;

namespace CinemaCounter.Models.DAO.Genre
{
    public interface IGenreDao
    {
        void Add(Entities.Genre genre);
        void Edit(Entities.Genre genre);
        void Delete(Entities.Genre genre);
        List<Entities.Genre> Load();
        List<Entities.Genre> Load(int id);
    }
}