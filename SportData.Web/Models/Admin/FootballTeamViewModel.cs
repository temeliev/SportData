using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportData.Web.Models.Admin
{
    public class FootballTeamViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public int? OriginalTeamId { get; set; }

        [Display(Name = "Иконка")]
        public string EmblemImageUrl { get; set; }

        public bool IsDeleted { get; set; }

        [Required(ErrorMessage = "Въведете име на отбора!")]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Display(Name = "Локация")]
        public string LocationName { get; set; }

        [Display(Name = "Локация")]
        public int LocationId { get; set; }

        public List<FootballTeamCultureViewModel> Cultures { get; set; }

        public List<FootballTeamPlayerViewModel> Players { get; set; }
    }
}