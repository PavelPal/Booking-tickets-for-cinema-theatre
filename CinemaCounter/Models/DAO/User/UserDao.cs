using System.Linq;

namespace CinemaCounter.Models.DAO.User
{
    public class UserDao : IUserDao
    {
        public int Count()
        {
            int result;
            using (var context = new ApplicationDbContext())
            {
                result = context.Users.Count();
            }
            return result;
        }
    }
}