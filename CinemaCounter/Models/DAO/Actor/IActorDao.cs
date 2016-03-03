using System.Collections.Generic;

namespace CinemaCounter.Models.DAO.Actor
{
    public interface IActorDao
    {
        void Add();
        void Edit();
        void Delete();
        Enities.Actor Load(int id);
        List<Enities.Actor> Load(int skip, int take);
    }
}