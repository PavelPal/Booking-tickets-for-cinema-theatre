using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaCounter.Models.Entities
{
    public class Session
    {
        public Session()
        {
            Tickets = new List<Ticket>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Не корректно введена дата")]
        [Display(Name = "Дата и время сеанса")]
        public DateTime Date { get; set; }

        public int SceneId { get; set; }
        public Scene Scene { get; set; }
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}