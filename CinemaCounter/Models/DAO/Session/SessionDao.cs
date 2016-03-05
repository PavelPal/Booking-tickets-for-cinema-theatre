using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CinemaCounter.Models.DAO.Session
{
    public class SessionDao : ISessionDao
    {
        public void Add(Entities.Session session)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Sessions.Add(session);
                context.SaveChanges();
            }
        }

        public void Edit(Entities.Session session)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(session).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var deleteItem = context.Sessions.FirstOrDefault(s => s.Id == id);
                if (deleteItem == null)
                    return;
                context.Sessions.Remove(deleteItem);
                context.SaveChanges();
            }
        }

        public Entities.Session Load(int id)
        {
            Entities.Session session;
            using (var context = new ApplicationDbContext())
            {
                session = context.Sessions.FirstOrDefault(s => s.Id == id);
            }
            return session;
        }

        public List<Entities.Session> Load(int skip, int take)
        {
            List<Entities.Session> sessions;
            using (var context = new ApplicationDbContext())
            {
                sessions = context.Sessions.OrderByDescending(s => s.Date).Skip(skip).Take(take).ToList();
            }
            return sessions;
        }

        public List<Entities.Session> Load(int id, int skip, int take)
        {
            List<Entities.Session> sessions;
            using (var context = new ApplicationDbContext())
            {
                sessions = context.Sessions.Where(s => s.Id == id).OrderByDescending(s => s.Date).Skip(skip).Take(take).ToList();
            }
            return sessions;
        }

        public List<Entities.Session> LoadToday(int skip, int take)
        {
            List<Entities.Session> sessions;
            using (var context = new ApplicationDbContext())
            {
                sessions = context.Sessions.Where(s => s.Date.Date == DateTime.Today).ToList();
            }
            return sessions;
        }

        public List<Entities.Session> LoadWeek(int skip, int take)
        {
            List<Entities.Session> sessions;
            using (var context = new ApplicationDbContext())
            {
                sessions =
                    context.Sessions.Where(
                        s =>
                            s.Date.Day <= (DateTime.Today.Date.Day + 6) &&
                            s.Date.Day >= (DateTime.Today.Date.Day - 6)
                        ).ToList();
            }
            return sessions;
        }

        public List<Entities.Session> LoadMonth(int skip, int take)
        {
            List<Entities.Session> sessions;
            using (var context = new ApplicationDbContext())
            {
                sessions =
                    context.Sessions.Where(
                        s =>
                            s.Date.Month <= DateTime.Today.Date.Month &&
                            s.Date.Month >= DateTime.Today.Date.Month
                        ).ToList();
            }
            return sessions;
        }

        public int Count()
        {
            int count;
            using (var context = new ApplicationDbContext())
            {
                count = context.Sessions.Count();
            }
            return count;
        }
    }
}