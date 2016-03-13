using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaCounter.Models.Entities
{
    public class Cinema
    {
        public Cinema()
        {
            Sessions = new List<Session>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Не корректно введено название кинотеатра")]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 3)]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не корректно введен город")]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 3)]
        [Display(Name = "Город")]
        public string Town { get; set; }

        [Required(ErrorMessage = "Не корректно введена улица")]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 3)]
        [Display(Name = "Улица")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Не корректно введен номер дома")]
        [StringLength(10, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 1)]
        [RegularExpression(@"^\d+[0-9]?(\w{1}?)([/]?)(\d?)",
            ErrorMessage = "Не корректно введен номер дома")]
        [Display(Name = "Номер дома")]
        public string Building { get; set; }

        [Display(Name = "Ближайшая станция метро")]
        public string Station { get; set; }

        [Required(ErrorMessage = "Не корректно введена ссылка на сайт")]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 3)]
        [Display(Name = "Ссылка на сайт")]
        public string WebSite { get; set; }

        [Required(ErrorMessage = "Не корректно введен номер телефона")]
        [RegularExpression(@"^([\+]?)((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,12}",
            ErrorMessage = "Не корректно введен номер телефона")]
        [Display(Name = "Номер телефона")]
        public string Phone { get; set; }

        public ICollection<Session> Sessions { get; set; }
    }
}