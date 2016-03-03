using System.Collections.Generic;

namespace CinemaCounter.Models.DAO.Company
{
    public interface ICompanyDao
    {
        void Add();
        void Edit();
        void Delete();
        Enities.Company Load(int id);
        List<Enities.Company> Load(int skip, int take);
    }
}