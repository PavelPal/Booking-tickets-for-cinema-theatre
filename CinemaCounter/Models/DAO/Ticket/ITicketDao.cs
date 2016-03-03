using System.Collections.Generic;

namespace CinemaCounter.Models.DAO.Ticket
{
    public interface ITicketDao
    {
        void Add();
        void Edit();
        void Delete();
        Enities.Ticket Load(int id);
        List<Enities.Ticket> Load(int skip, int take);
    }
}