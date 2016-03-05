using System.Collections.Generic;

namespace CinemaCounter.Models.DAO.Actor
{
    public interface IActorDao
    {
        void Add(Entities.Actor actor);
        void Edit(Entities.Actor actor);
        void Delete(int id);
        Entities.Actor Load(int id);
        List<Entities.Actor> Load(int skip, int take);
        int Count();
    }
}