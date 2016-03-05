using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CinemaCounter.Models.DAO.Genre
{
    public class GenreDao : IGenreDao
    {
        public void Add(Entities.Genre genre)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Genres.Add(genre);
                context.SaveChanges();
            }
        }

        public void Edit(Entities.Genre genre)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(genre).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Entities.Genre genre)
        {
            using (var context = new ApplicationDbContext())
            {
                var deleteItem = context.Genres.FirstOrDefault(g => g.Id == genre.Id);
                if (deleteItem == null)
                    return;
                context.Genres.Remove(deleteItem);
                context.SaveChanges();
            }
        }

        public List<Entities.Genre> Load()
        {
            List<Entities.Genre> genres;
            using (var context = new ApplicationDbContext())
            {
                genres = context.Genres.ToList();
            }
            return genres;
        }

        public List<Entities.Genre> Load(int id)
        {
            List<Entities.Genre> genres;
            Entities.Scene scene;
            using (var context = new ApplicationDbContext())
            {
                scene = context.Scenes.FirstOrDefault(s => s.Id == id);
                genres = context.Genres.Where(g => g.Scenes.Contains(scene)).ToList();
            }
            return genres;
        }
    }
}