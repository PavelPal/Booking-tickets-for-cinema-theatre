using System.Collections.Generic;

namespace CinemaCounter.Models.DAO.Scene
{
    public interface ISceneDao
    {
        void Add();
        void Edit();
        void Delete();
        Enities.Scene Load(int id);
        List<Enities.Scene> Load(int skip, int take);
    }
}