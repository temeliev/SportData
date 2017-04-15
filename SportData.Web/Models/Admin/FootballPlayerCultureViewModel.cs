using System.ComponentModel.DataAnnotations;

namespace SportData.Web.Models.Admin
{
    public class FootballPlayerCultureViewModel
    {
        public int FootballPlayerId { get; set; }

        public int CultureId { get; set; }

        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Display(Name = "Презиме")]
        public string SecondName { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Език")]
        public string CultureName { get; set; }
    }
}