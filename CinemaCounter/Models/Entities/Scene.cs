using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaCounter.Models.Entities
{
    public class Scene
    {
        public Scene()
        {
            Actors = new List<Actor>();
            Genres = new List<Genre>();
            Cinemas = new List<Cinema>();
            Sessions = new List<Session>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Не корректно введено название фильма")]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 3)]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не корректно введено описание фильма")]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 3)]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Не корректно выбрана дата создания")]
        [Display(Name = "Дата создания")]
        public DateTime DataOfCreated { get; set; }

        [Required(ErrorMessage = "Не корректно введена продолжительность")]
        [Display(Name = "Продолжительность")]
        public int Duration { get; set; }

        [DefaultValue(0)]
        [Display(Name = "Отценка")]
        public double Mark { get; set; }

        public string ImagePath { get; set; }
        public ICollection<Actor> Actors { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Cinema> Cinemas { get; set; }
        public ICollection<Session> Sessions { get; set; }
        public Company Company { get; set; }
        public Director Director { get; set; }
    }
}