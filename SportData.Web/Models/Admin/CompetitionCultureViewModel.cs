using System.ComponentModel.DataAnnotations;

namespace SportData.Web.Models.Admin
{
    public class CompetitionCultureViewModel : BaseViewModel
    {
        public int CompetitionId { get; set; }

        [Display(Name = "Име")]
        [Required(ErrorMessage = "Въведете превод на състезанието!")]
        public string CompetitionName { get; set; }

        [Display(Name = "Език")]
        [Required(ErrorMessage = "Изберете език!")]
        public int CultureId { get; set; }

        [Display(Name = "Език")]
        public string CultureName { get; set; }
    }
}