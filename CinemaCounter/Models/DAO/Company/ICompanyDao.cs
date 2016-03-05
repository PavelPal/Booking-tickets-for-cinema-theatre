using System.Collections.Generic;

namespace CinemaCounter.Models.DAO.Company
{
    public interface ICompanyDao
    {
        void Add(Entities.Company company);
        void Edit(Entities.Company company);
        void Delete(int id);
        Entities.Company Load(int id);
        List<Entities.Company> Load(int skip, int take);
        int Count();
    }
}