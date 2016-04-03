using System.Collections.Generic;

namespace CinemaCounter.Models.DAO.Message
{
    public interface IMessageDao
    {
        void Add(Entities.Message message);
        void Edit(Entities.Message message);
        void Delete(int id);
        Entities.Message Load(int id);
        List<Entities.Message> Load();
        int Count();
    }
}