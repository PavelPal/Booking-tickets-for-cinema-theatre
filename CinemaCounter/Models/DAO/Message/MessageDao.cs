using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CinemaCounter.Models.DAO.Message
{
    public class MessageDao : IMessageDao
    {
        public void Add(Entities.Message message)
        {
            message.Date = DateTime.Now;
            using (var context = new ApplicationDbContext())
            {
                context.Messages.Add(message);
                context.SaveChanges();
            }
        }

        public void Edit(Entities.Message message)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(message).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var deleteItem = context.Messages.FirstOrDefault(a => a.Id == id);
                if (deleteItem == null)
                    return;
                context.Messages.Remove(deleteItem);
                context.SaveChanges();
            }
        }

        public Entities.Message Load(int id)
        {
            Entities.Message message;
            using (var context = new ApplicationDbContext())
            {
                message = context.Messages.FirstOrDefault(a => a.Id == id);
            }
            return message;
        }

        public List<Entities.Message> Load()
        {
            List<Entities.Message> messages;
            using (var context = new ApplicationDbContext())
            {
                messages = context.Messages.OrderByDescending(g => g.Date).ToList();
            }
            return messages;
        }

        public int Count()
        {
            int count;
            using (var context = new ApplicationDbContext())
            {
                count = context.Messages.Count();
            }
            return count;
        }
    }
}