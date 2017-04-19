using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportData.Web.Models.Admin
{
    public class FootballTeamViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public int? OriginalTeamId { get; set; }

        public string EmblemImageUrl { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        [Display(Name = "Име")]
        public string Name { get; set; }

        public string LocationName { get; set; }

        public int LocationId { get; set; }

        public List<FootballTeamCultureViewModel> Cultures { get; set; }

        public List<FootballTeamPlayerViewModel> Players { get; set; }
    }
}