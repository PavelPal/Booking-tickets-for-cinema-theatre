using System.Collections.Generic;
using CinemaCounter.Models.DAO.Cinema;
using CinemaCounter.Models.DAO.Session;
using CinemaCounter.Models.Entities;

namespace CinemaCounter.Models.Cinema
{
    public class CinemaService : ICinemaService
    {
        private readonly ICinemaDao _cinemaDao;
        private readonly ISessionDao _sessionDao;

        public CinemaService(ICinemaDao cinemaDao, ISessionDao sessionDao)
        {
            _cinemaDao = cinemaDao;
            _sessionDao = sessionDao;
        }

        public CinemaViewModel Show(int id)
        {
            var viewModel = new CinemaViewModel
            {
                Cinema = _cinemaDao.Load(id),
                Sessions = _sessionDao.Load(id, 0, 3)
            };
            return viewModel;
        }

        public List<Session> LoadMoreSessions(int id, int skip)
        {
            var sessions = _sessionDao.Load(id, skip, 9);
            return sessions;
        }
    }
}