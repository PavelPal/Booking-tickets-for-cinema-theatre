using System.Collections.Generic;
using CinemaCounter.Models.DAO.Cinema;
using CinemaCounter.Models.DAO.Session;
using CinemaCounter.Models.Entities;

namespace CinemaCounter.Models.Home
{
    public class HomeService : IHomeService
    {
        private readonly ICinemaDao _cinemaDao;
        private readonly ISessionDao _sessionDao;

        public HomeService(ICinemaDao cinemaDao, ISessionDao sessionDao)
        {
            _cinemaDao = cinemaDao;
            _sessionDao = sessionDao;
        }

        public IndexViewModel Show()
        {
            var viewModel = new IndexViewModel
            {
                Cinemas = _cinemaDao.Load(0, 3),
                Sessions = _sessionDao.Load(0, 3)
            };
            return viewModel;
        }

        public List<Entities.Cinema> LoadMoreCinemas(int skip)
        {
            var cinemas = _cinemaDao.Load(skip, 9);
            return cinemas;
        }

        public List<Session> LoadMoreSessions(int skip)
        {
            var sessions = _sessionDao.Load(skip, 9);
            return sessions;
        }
    }
}