using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaCounter.Models.Entities
{
    public class Message
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Не корректно введена тема сообщения")]
        [StringLength(30, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 0)]
        [Display(Name = "Тема")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Не корректно введен e-mail")]
        [StringLength(30, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 3)]
        [Display(Name = "E-mail")]
        [EmailAddress]
        public string Sender { get; set; }

        [Required(ErrorMessage = "Не корректно введено сообщение")]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 3)]
        [Display(Name = "Сообщение")]
        public string Body { get; set; }

        public DateTime Date { get; set; }
    }
}