using System.ComponentModel.DataAnnotations;

namespace SportData.Web.Models.Admin
{
    public class FootballTeamCultureViewModel : BaseViewModel
    {
        public int FootballTeamId { get; set; }

        [Display(Name = "Име")]
        public string FootballTeamName { get; set; }

        public int CultureId { get; set; }

        [Display(Name = "Език")]
        public string CultureName { get; set; }
    }
}