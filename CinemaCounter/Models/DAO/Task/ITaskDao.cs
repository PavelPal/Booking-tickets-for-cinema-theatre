using System.Collections.Generic;

namespace CinemaCounter.Models.DAO.Task
{
    public interface ITaskDao
    {
        void Add(Entities.Task task);
        void Edit(Entities.Task task);
        void Delete(int id);
        Entities.Task Load(int id);
        List<Entities.Task> Load();
    }
}