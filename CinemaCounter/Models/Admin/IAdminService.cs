using System.Collections.Generic;
using CinemaCounter.Models.Entities;

namespace CinemaCounter.Models.Admin
{
    public interface IAdminService
    {
        IndexViewModel Inicialize();
        Task AddTask(string body, string goal);
        void DeleteTask(int id);
        void TogglePriority(int id);
        void ToggleState(int id);
        List<Entities.Cinema> Cinemas();
        List<Entities.Cinema> LoadMoreCinemas(int skip);
    }
}