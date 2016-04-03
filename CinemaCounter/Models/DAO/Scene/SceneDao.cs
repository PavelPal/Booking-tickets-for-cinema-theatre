using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CinemaCounter.Models.DAO.Scene
{
    public class SceneDao : ISceneDao
    {
        public void Add(Entities.Scene scene)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Scenes.Add(scene);
                context.SaveChanges();
            }
        }

        public void Edit(Entities.Scene scene)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(scene).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var deleteItem = context.Scenes.FirstOrDefault(s => s.Id == id);
                if (deleteItem == null)
                    return;
                context.Scenes.Remove(deleteItem);
                context.SaveChanges();
            }
        }

        public Entities.Scene Load(int id)
        {
            Entities.Scene scene;
            using (var context = new ApplicationDbContext())
            {
                scene = context.Scenes.FirstOrDefault(s => s.Id == id);
            }
            return scene;
        }

        public List<Entities.Scene> Load()
        {
            List<Entities.Scene> scenes;
            using (var context = new ApplicationDbContext())
            {
                scenes = context.Scenes.ToList();
            }
            return scenes;
        }

        public List<Entities.Scene> Load(int skip, int take)
        {
            List<Entities.Scene> scenes;
            using (var context = new ApplicationDbContext())
            {
                scenes = context.Scenes.OrderByDescending(s => s.DataOfCreated).Skip(skip).Take(take).ToList();
            }
            return scenes;
        }

        public int Count()
        {
            int count;
            using (var context = new ApplicationDbContext())
            {
                count = context.Scenes.Count();
            }
            return count;
        }
    }
}