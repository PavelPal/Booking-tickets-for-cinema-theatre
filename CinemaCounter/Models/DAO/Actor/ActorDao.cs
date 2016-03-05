using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CinemaCounter.Models.DAO.Actor
{
    public class ActorDao : IActorDao
    {
        public void Add(Entities.Actor actor)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Actors.Add(actor);
                context.SaveChanges();
            }
        }

        public void Edit(Entities.Actor actor)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(actor).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var deleteItem = context.Actors.FirstOrDefault(a => a.Id == id);
                if (deleteItem == null)
                    return;
                context.Actors.Remove(deleteItem);
                context.SaveChanges();
            }
        }

        public Entities.Actor Load(int id)
        {
            Entities.Actor actor;
            using (var context = new ApplicationDbContext())
            {
                actor = context.Actors.FirstOrDefault(a => a.Id == id);
            }
            return actor;
        }

        public List<Entities.Actor> Load(int skip, int take)
        {
            List<Entities.Actor> actors;
            using (var context = new ApplicationDbContext())
            {
                actors = context.Actors.OrderBy(g => g.Name).Skip(skip).Take(take).ToList();
            }
            return actors;
        }

        public int Count()
        {
            int count;
            using (var context = new ApplicationDbContext())
            {
                count = context.Actors.Count();
            }
            return count;
        }
    }
}