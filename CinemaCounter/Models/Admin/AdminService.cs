using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Mvc;
using CinemaCounter.Models.DAO.Actor;
using CinemaCounter.Models.DAO.Cinema;
using CinemaCounter.Models.DAO.Company;
using CinemaCounter.Models.DAO.Director;
using CinemaCounter.Models.DAO.Genre;
using CinemaCounter.Models.DAO.Message;
using CinemaCounter.Models.DAO.Scene;
using CinemaCounter.Models.DAO.Session;
using CinemaCounter.Models.DAO.Task;
using CinemaCounter.Models.DAO.Ticket;
using CinemaCounter.Models.DAO.User;
using CinemaCounter.Models.Entities;

namespace CinemaCounter.Models.Admin
{
    public class AdminService : IAdminService
    {
        private readonly IActorDao _actorDao;
        private readonly ICinemaDao _cinemaDao;
        private readonly ICompanyDao _companyDao;
        private readonly IDirectorDao _directorDao;
        private readonly IGenreDao _genreDao;
        private readonly IMessageDao _messageDao;
        private readonly ISceneDao _sceneDao;
        private readonly ISessionDao _sessionDao;
        private readonly ITaskDao _taskDao;
        private readonly ITicketDao _ticketDao;
        private readonly IUserDao _userDao;

        public AdminService(ICinemaDao cinemaDao, ISessionDao sessionDao, ITicketDao ticketDao, IUserDao userDao,
            ITaskDao taskDao, ISceneDao sceneDao, IActorDao actorDao, IGenreDao genreDao, ICompanyDao companyDao,
            IDirectorDao directorDao, IMessageDao messageDao)
        {
            _cinemaDao = cinemaDao;
            _sessionDao = sessionDao;
            _ticketDao = ticketDao;
            _userDao = userDao;
            _taskDao = taskDao;
            _sceneDao = sceneDao;
            _actorDao = actorDao;
            _genreDao = genreDao;
            _companyDao = companyDao;
            _directorDao = directorDao;
            _messageDao = messageDao;
        }

        public IndexViewModel Inicialize()
        {
            var viewModel = new IndexViewModel
            {
                CinemasCount = _cinemaDao.Count(),
                SessionsCount = _sessionDao.Count(),
                ThicketsCount = _ticketDao.Count(),
                UsersCount = _userDao.Count(),
                Tasks = _taskDao.Load(),
                Messages = _messageDao.Load()
            };
            return viewModel;
        }

        public SessionViewModel InicializeForSessions()
        {
            var viewModel = new SessionViewModel();
            viewModel.Cinemas.Add(new SelectListItem
            {
                Text = "Выберите кинотеатр",
                Value = "",
                Disabled = true,
                Selected = true
            });
            foreach (var item in _cinemaDao.Load())
            {
                viewModel.Cinemas.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString(),
                    Disabled = false,
                    Selected = false
                });
            }
            viewModel.Scenes.Add(new SelectListItem
            {
                Text = "Выберите фильм",
                Value = "",
                Disabled = true,
                Selected = true
            });
            foreach (var item in _sceneDao.Load())
            {
                viewModel.Scenes.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString(),
                    Disabled = false,
                    Selected = false
                });
            }
            return viewModel;
        }

        public SessionViewModel InicializeForEditSessions(int id)
        {
            var viewModel = new SessionViewModel();
            viewModel.Cinemas.Add(new SelectListItem
            {
                Text = "Выберите кинотеатр",
                Value = "",
                Disabled = true,
                Selected = true
            });
            foreach (var item in _cinemaDao.Load())
            {
                viewModel.Cinemas.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString(),
                    Disabled = false,
                    Selected = false
                });
            }
            viewModel.Scenes.Add(new SelectListItem
            {
                Text = "Выберите фильм",
                Value = "",
                Disabled = true,
                Selected = true
            });
            foreach (var item in _sceneDao.Load())
            {
                viewModel.Scenes.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString(),
                    Disabled = false,
                    Selected = false
                });
            }
            viewModel.Session = Load(id);
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

        public void ChangeTaskBody(int id, string body)
        {
            var task = _taskDao.Load(id);
            task.Body = body;
            _taskDao.Edit(task);
        }

        public List<Scene> Scenes(int skip, int take)
        {
            var scenesModel = _sceneDao.Load(skip, take);
            return scenesModel;
        }

        public void AddScene(Scene model)
        {
            _sceneDao.Add(model);
        }

        public void AddCinemas(Entities.Cinema cinema)
        {
            _cinemaDao.Add(cinema);
        }

        /// <exception cref="FormatException">
        ///     <paramref name="value" /> не состоит из необязательного знака и следующей за ним
        ///     последовательности цифр (от 0 до 9).
        /// </exception>
        /// <exception cref="OverflowException">
        ///     <paramref name="value" /> представляет число, которое меньше
        ///     <see cref="F:System.Int32.MinValue" /> или больше <see cref="F:System.Int32.MaxValue" />.
        /// </exception>
        public void AddSession(string cinema, string scene, string date)
        {
            var cinemaToInt = Convert.ToInt32(cinema);
            var sceneToInt = Convert.ToInt32(scene);
            var dateToDate = DateTime.ParseExact(date, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            _sessionDao.Add(cinemaToInt, sceneToInt, dateToDate);
        }

        /// <exception cref="FormatException">
        ///     <paramref name="value" /> не состоит из необязательного знака и следующей за ним
        ///     последовательности цифр (от 0 до 9).
        /// </exception>
        /// <exception cref="OverflowException">
        ///     <paramref name="value" /> представляет число, которое меньше
        ///     <see cref="F:System.Int32.MinValue" /> или больше <see cref="F:System.Int32.MaxValue" />.
        /// </exception>
        public void EditSession(string cinema, string scene, Session session)
        {
            var cinemaToInt = Convert.ToInt32(cinema);
            var sceneToInt = Convert.ToInt32(scene);
            session.Cinema = _cinemaDao.Load(cinemaToInt);
            session.Scene = _sceneDao.Load(sceneToInt);
            _sessionDao.Edit(session);
        }

        public void EditScene(Scene scene)
        {
            _sceneDao.Edit(scene);
        }

        public void AddActor(Actor actor)
        {
            _actorDao.Add(actor);
        }

        public void AddGenre(Genre genre)
        {
            _genreDao.Add(genre);
        }

        public void AddCompany(Company company)
        {
            _companyDao.Add(company);
        }

        public void AddDirector(Director director)
        {
            _directorDao.Add(director);
        }

        public Session Load(int id)
        {
            var session = _sessionDao.Load(id);
            return session;
        }

        public Scene LoadScene(int id)
        {
            var model = _sceneDao.Load(id);
            return model;
        }

        public List<Entities.Cinema> Show()
        {
            var model = _cinemaDao.Load(0, 3);
            return model;
        }

        public List<Entities.Cinema> LoadMoreCinemas(int skip)
        {
            var cinemas = _cinemaDao.Load(skip, 9);
            return cinemas;
        }

        public Entities.Cinema LoadCinema(int id)
        {
            var model = _cinemaDao.Load(id);
            return model;
        }

        public void DeleteCinema(int id)
        {
            _cinemaDao.Delete(id);
        }

        public Entities.Cinema GetCinema(int id)
        {
            var model = _cinemaDao.Load(id);
            return model;
        }

        public void UpdateCinema(Entities.Cinema cinema)
        {
            _cinemaDao.Edit(cinema);
        }

        public Session GetSession(int id)
        {
            var model = _sessionDao.Load(id);
            return model;
        }

        public void DeleteSession(int id)
        {
            _sessionDao.Delete(id);
        }

        public List<Ticket> LoadTickets()
        {
            var model = _ticketDao.Load(0, _ticketDao.Count());
            return model;
        }
    }
}