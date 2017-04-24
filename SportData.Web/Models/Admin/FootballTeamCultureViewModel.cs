using System.ComponentModel.DataAnnotations;

namespace SportData.Web.Models.Admin
{
    public class FootballTeamCultureViewModel : BaseViewModel
    {
        public int FootballTeamId { get; set; }

        [Display(Name = "Име")]
        [Required(ErrorMessage = "Въведете име на отбора!")]
        public string FootballTeamName { get; set; }

        [Display(Name = "Език")]
        [Required(ErrorMessage = "Изберете език!")]
        public int CultureId { get; set; }

        [Display(Name = "Език")]
        public string CultureName { get; set; }
    }
}