using System.Collections.Generic;

namespace SportData.Web.Models
{
    public class GroupedMatchesViewModel
    {
        public int FootballCompetitionId { get; set; }

        public string FootballCompetitionName { get; set; }

        public string CompetitionLocationFlagUrl { get; set; }

        public string CompetitionLocationName { get; set; }

        public List<FootballMatchViewModel> Matches { get; set; }
    }
}