using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CinemaCounter.Models.DAO.Company
{
    public class CompanyDao : ICompanyDao
    {
        public void Add(Entities.Company company)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Companies.Add(company);
                context.SaveChanges();
            }
        }

        public void Edit(Entities.Company company)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(company).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var deleteItem = context.Companies.FirstOrDefault(c => c.Id == id);
                if (deleteItem == null)
                    return;
                context.Companies.Remove(deleteItem);
                context.SaveChanges();
            }
        }

        public Entities.Company Load(int id)
        {
            Entities.Company company;
            using (var context = new ApplicationDbContext())
            {
                company = context.Companies.FirstOrDefault(c => c.Id == id);
            }
            return company;
        }

        public List<Entities.Company> Load(int skip, int take)
        {
            List<Entities.Company> companies;
            using (var context = new ApplicationDbContext())
            {
                companies = context.Companies.OrderBy(c => c.Name).Skip(skip).Take(take).ToList();
            }
            return companies;
        }

        public int Count()
        {
            int count;
            using (var context = new ApplicationDbContext())
            {
                count = context.Companies.Count();
            }
            return count;
        }
    }
}