using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CinemaCounter.Models.DAO.Cinema
{
    public class CinemaDao : ICinemaDao
    {
        public void Add(Entities.Cinema cinema)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Cinemas.Add(cinema);
                context.SaveChanges();
            }
        }

        public void Edit(Entities.Cinema cinema)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(cinema).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var deleteItem = context.Cinemas.FirstOrDefault(c => c.Id == id);
                if (deleteItem == null)
                    return;
                context.Cinemas.Remove(deleteItem);
                context.SaveChanges();
            }
        }

        public Entities.Cinema Load(int id)
        {
            Entities.Cinema cinema;
            using (var context = new ApplicationDbContext())
            {
                cinema = context.Cinemas.FirstOrDefault(c => c.Id == id);
            }
            return cinema;
        }

        public List<Entities.Cinema> Load()
        {
            List<Entities.Cinema> cinemas;
            using (var context = new ApplicationDbContext())
            {
                cinemas = context.Cinemas.ToList();
            }
            return cinemas;
        }

        public List<Entities.Cinema> Load(int skip, int take)
        {
            List<Entities.Cinema> cinemas;
            using (var context = new ApplicationDbContext())
            {
                cinemas = context.Cinemas.OrderBy(c => c.Name).Skip(skip).Take(take).ToList();
            }
            return cinemas;
        }

        public int Count()
        {
            int count;
            using (var context = new ApplicationDbContext())
            {
                count = context.Cinemas.Count();
            }
            return count;
        }
    }
}