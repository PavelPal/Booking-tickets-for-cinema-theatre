using System.Collections.Generic;
using CinemaCounter.Models.DAO.Cinema;
using CinemaCounter.Models.DAO.Session;
using CinemaCounter.Models.DAO.Task;
using CinemaCounter.Models.DAO.Ticket;
using CinemaCounter.Models.DAO.User;
using CinemaCounter.Models.Entities;

namespace CinemaCounter.Models.Admin
{
    public class AdminService : IAdminService
    {
        private readonly ICinemaDao _cinemaDao;
        private readonly ISessionDao _sessionDao;
        private readonly ITaskDao _taskDao;
        private readonly ITicketDao _ticketDao;
        private readonly IUserDao _userDao;

        public AdminService(ICinemaDao cinemaDao, ISessionDao sessionDao, ITicketDao ticketDao, IUserDao userDao,
            ITaskDao taskDao)
        {
            _cinemaDao = cinemaDao;
            _sessionDao = sessionDao;
            _ticketDao = ticketDao;
            _userDao = userDao;
            _taskDao = taskDao;
        }

        public IndexViewModel Inicialize()
        {
            var viewModel = new IndexViewModel
            {
                CinemasCount = _cinemaDao.Count(),
                SessionsCount = _sessionDao.Count(),
                ThicketsCount = _ticketDao.Count(),
                UsersCount = _userDao.Count(),
                Tasks = _taskDao.Load()
            };
            return viewModel;
        }

        public Task AddTask(string body, string goal)
        {
            var task = new Task
            {
                Body = body,
                Goal = goal
            };
            _taskDao.Add(task);
            return task;
        }

        public void DeleteTask(int id)
        {
            _taskDao.Delete(id);
        }

        public void TogglePriority(int id)
        {
            var task = _taskDao.Load(id);
            task.IsImportant = !task.IsImportant;
            _taskDao.Edit(task);
        }

        public void ToggleState(int id)
        {
            var task = _taskDao.Load(id);
            task.IsDone = !task.IsDone;
            _taskDao.Edit(task);
        }

        public List<Entities.Cinema> Cinemas()
        {
            var cinemas = _cinemaDao.Load(0, 9);
            return cinemas;
        }

        public List<Entities.Cinema> LoadMoreCinemas(int skip)
        {
            var cinemas = _cinemaDao.Load(skip, 9);
            return cinemas;
        }
    }
}