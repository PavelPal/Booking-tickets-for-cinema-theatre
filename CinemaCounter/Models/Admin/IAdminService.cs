using System.Collections.Generic;
using CinemaCounter.Models.Entities;

namespace CinemaCounter.Models.Admin
{
    public interface IAdminService
    {
        IndexViewModel Inicialize();
        SessionViewModel InicializeForSessions();
        SessionViewModel InicializeForEditSessions(int id);
        Task AddTask(string body, string goal);
        void DeleteTask(int id);
        void TogglePriority(int id);
        void ToggleState(int id);
        void ChangeTaskBody(int id, string body);
        List<Scene> Scenes(int skip, int take);
        void AddScene(Scene model);
        void AddCinemas(Entities.Cinema cinema);
        void AddSession(string cinema, string scene, string date);
        void EditSession(string cinema, string scene, Session session);
        void EditScene(Scene scene);
        void AddActor(Actor actor);
        void AddGenre(Genre genre);
        void AddCompany(Company company);
        void AddDirector(Director director);
        Session Load(int id);
        Scene LoadScene(int id);
        List<Entities.Cinema> Show();
        List<Entities.Cinema> LoadMoreCinemas(int skip);
        Entities.Cinema LoadCinema(int id);
        void DeleteCinema(int id);
        Entities.Cinema GetCinema(int id);
        void UpdateCinema(Entities.Cinema cinema);
        Session GetSession(int id);
        void DeleteSession(int id);
        List<Ticket> LoadTickets();
    }
}