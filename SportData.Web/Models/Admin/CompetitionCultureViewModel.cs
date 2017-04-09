using System.ComponentModel.DataAnnotations;

namespace SportData.Web.Models.Admin
{
    public class CompetitionCultureViewModel
    {
        public int CompetitionId { get; set; }

        [Display(Name = "Име")]
        public string CompetitionName { get; set; }

        public int CultureId { get; set; }

        [Display(Name = "Език")]
        public string CultureName { get; set; }
    }
}