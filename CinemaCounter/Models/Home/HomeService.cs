using System.Collections.Generic;
using CinemaCounter.Models.DAO.Cinema;
using CinemaCounter.Models.DAO.Message;
using CinemaCounter.Models.DAO.Session;
using CinemaCounter.Models.DAO.Ticket;
using CinemaCounter.Models.Entities;

namespace CinemaCounter.Models.Home
{
    public class HomeService : IHomeService
    {
        private readonly ICinemaDao _cinemaDao;
        private readonly IMessageDao _messageDao;
        private readonly ISessionDao _sessionDao;
        private readonly ITicketDao _ticketDao;

        public HomeService(ICinemaDao cinemaDao, ISessionDao sessionDao, IMessageDao messageDao, ITicketDao ticketDao)
        {
            _cinemaDao = cinemaDao;
            _sessionDao = sessionDao;
            _messageDao = messageDao;
            _ticketDao = ticketDao;
        }

        public List<Session> LoaSessions()
        {
            var model = _sessionDao.Load(0, 3);
            return model;
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

        public void SendMessage(Message message)
        {
            _messageDao.Add(message);
        }

        public List<Session> LoadSessionsToday()
        {
            var model = _sessionDao.LoadToday();
            return model;
        }

        public List<Session> LoadSessionsWeek()
        {
            var model = _sessionDao.LoadWeek();
            return model;
        }

        public List<Session> LoadSessionsMonth()
        {
            var model = _sessionDao.LoadMonth();
            return model;
        }

        public Session LoadSession(int id)
        {
            var model = _sessionDao.Load(id);
            return model;
        }

        public Ticket InicializeForBooking(int id)
        {
            var ticket = new Ticket
            {
                Session = _sessionDao.Load(id),
                Cost = 80000
            };
            return ticket;
        }

        public void Booking(Ticket ticket)
        {
            _ticketDao.Add(ticket);
        }
    }
}