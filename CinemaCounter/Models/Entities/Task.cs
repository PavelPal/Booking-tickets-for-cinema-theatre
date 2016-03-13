using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaCounter.Models.Entities
{
    public class Task
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Не корректно введено задание")]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 3)]
        [Display(Name = "Задание")]
        public string Body { get; set; }

        [DefaultValue(false)]
        public bool IsDone { get; set; }

        [DefaultValue(false)]
        public bool IsImportant { get; set; }

        public string Goal { get; set; }
    }
}