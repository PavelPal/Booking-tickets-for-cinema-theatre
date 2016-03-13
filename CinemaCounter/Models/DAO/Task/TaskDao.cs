using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CinemaCounter.Models.DAO.Task
{
    public class TaskDao : ITaskDao
    {
        public void Add(Entities.Task task)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Tasks.Add(task);
                context.SaveChanges();
            }
        }

        public void Edit(Entities.Task task)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(task).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var deleteItem = context.Tasks.FirstOrDefault(t => t.Id == id);
                context.Tasks.Remove(deleteItem);
                context.SaveChanges();
            }
        }

        public Entities.Task Load(int id)
        {
            Entities.Task task;
            using (var context = new ApplicationDbContext())
            {
                task = context.Tasks.FirstOrDefault(t => t.Id == id);
            }
            return task;
        }

        public List<Entities.Task> Load()
        {
            List<Entities.Task> tasks;
            using (var context = new ApplicationDbContext())
            {
                tasks = context.Tasks.ToList();
            }
            return tasks;
        }
    }
}