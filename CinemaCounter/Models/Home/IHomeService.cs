using System.Collections.Generic;
using CinemaCounter.Models.Entities;

namespace CinemaCounter.Models.Home
{
    public interface IHomeService
    {
        List<Session> LoaSessions();
        IndexViewModel Show();
        List<Entities.Cinema> LoadMoreCinemas(int skip);
        List<Session> LoadMoreSessions(int skip);
        void SendMessage(Message message);
        List<Session> LoadSessionsToday();
        List<Session> LoadSessionsWeek();
        List<Session> LoadSessionsMonth();
        Session LoadSession(int id);
        Ticket InicializeForBooking(int id);
        void Booking(Ticket ticket);
    }
}