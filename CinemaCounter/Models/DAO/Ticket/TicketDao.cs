using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CinemaCounter.Models.DAO.Ticket
{
    public class TicketDao : ITicketDao
    {
        public void Add(Entities.Ticket ticket)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Tickets.Add(ticket);
                context.SaveChanges();
            }
        }

        public void Edit(Entities.Ticket ticket)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(ticket).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var deleteItem = context.Tickets.FirstOrDefault(t => t.Id == id);
                if (deleteItem == null)
                    return;
                context.Tickets.Remove(deleteItem);
                context.SaveChanges();
            }
        }

        public Entities.Ticket Load(int id)
        {
            Entities.Ticket ticket;
            using (var context = new ApplicationDbContext())
            {
                ticket = context.Tickets.FirstOrDefault(t => t.Id == id);
            }
            return ticket;
        }

        public List<Entities.Ticket> Load(int skip, int take)
        {
            List<Entities.Ticket> tickets;
            using (var context = new ApplicationDbContext())
            {
                tickets = context.Tickets.OrderBy(t => t.CustomerName).Skip(skip).Take(take).ToList();
            }
            return tickets;
        }

        public int Count()
        {
            int count;
            using (var context = new ApplicationDbContext())
            {
                count = context.Tickets.Count();
            }
            return count;
        }
    }
}