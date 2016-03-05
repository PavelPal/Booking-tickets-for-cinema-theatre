using System.Collections.Generic;

namespace CinemaCounter.Models.DAO.Ticket
{
    public interface ITicketDao
    {
        void Add(Entities.Ticket ticket);
        void Edit(Entities.Ticket ticket);
        void Delete(int id);
        Entities.Ticket Load(int id);
        List<Entities.Ticket> Load(int skip, int take);
        int Count();
    }
}