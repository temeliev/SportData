using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportData.Web.Models.Admin
{
    public class CompetitionViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Име")]
        public string Name { get; set; }

        public int? OriginalCompetitionId { get; set; }

        public int LocationId { get; set; }

        [Display(Name = "Локация")]
        public string LocationName { get; set; }

        public string CompetitionImageUrl { get; set; }

        [Display(Name = "Активен")]
        public bool IsActive { get; set; }

        public List<CompetitionCultureViewModel> Cultures { get; set; }

        public List<CompetitionViewModel> History { get; set; }
    }
}