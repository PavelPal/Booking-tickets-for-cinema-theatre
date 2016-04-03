using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaCounter.Models.Entities
{
    public class Ticket
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Не корректно введен e-mail")]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 3)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Не корректно введена цена")]
        [Display(Name = "Цена")]
        public decimal Cost { get; set; }

        public Session Session { get; set; }
    }
}