using System.ComponentModel.DataAnnotations;

namespace SportData.Web.Models.Admin
{
    public class FootballPlayerCultureViewModel : BaseViewModel
    {
        public int FootballPlayerId { get; set; }

        [Display(Name = "Език")]
        [Required(ErrorMessage = "Изберете език!")]
        public int CultureId { get; set; }

        [Display(Name = "Име")]
        [Required(ErrorMessage = "Въведете име на футболиста!")]
        public string FirstName { get; set; }

        [Display(Name = "Презиме")]
        public string SecondName { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Въведете фамилия на футболиста!")]
        public string LastName { get; set; }

        [Display(Name = "Език")]
        public string CultureName { get; set; }
    }
}