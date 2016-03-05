using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CinemaCounter.Models.DAO.Director
{
    public class DirectorDao : IDirectorDao
    {
        public void Add(Entities.Director director)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Directors.Add(director);
                context.SaveChanges();
            }
        }

        public void Edit(Entities.Director director)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(director).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var deleteItem = context.Directors.FirstOrDefault(d => d.Id == id);
                if (deleteItem == null)
                    return;
                context.Directors.Remove(deleteItem);
                context.SaveChanges();
            }
        }

        public Entities.Director Load(int id)
        {
            Entities.Director director;
            using (var context = new ApplicationDbContext())
            {
                director = context.Directors.FirstOrDefault(d => d.Id == id);
            }
            return director;
        }

        public List<Entities.Director> Load(int skip, int take)
        {
            List<Entities.Director> directors;
            using (var context = new ApplicationDbContext())
            {
                directors = context.Directors.OrderBy(d => d.Name).Skip(skip).Take(take).ToList();
            }
            return directors;
        }

        public int Count()
        {
            int count;
            using (var context = new ApplicationDbContext())
            {
                count = context.Directors.Count();
            }
            return count;
        }
    }
}