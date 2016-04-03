using System.Collections.Generic;

namespace CinemaCounter.Models.DAO.Scene
{
    public interface ISceneDao
    {
        void Add(Entities.Scene scene);
        void Edit(Entities.Scene scene);
        void Delete(int id);
        Entities.Scene Load(int id);
        List<Entities.Scene> Load();
        List<Entities.Scene> Load(int skip, int take);
        int Count();
    }
}