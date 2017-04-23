using System.Collections.Generic;
using SportData.Data.Enums;

namespace SportData.Web.Models
{
    public class FootballMatchesViewModel
    {
        public string SelectedDate { get; set; }

        public MatchStatus MatchStatus { get; set; }

        public List<GroupedMatchesViewModel> Matches { get; set; }
    }
}