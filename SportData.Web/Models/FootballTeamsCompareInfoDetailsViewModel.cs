using SportData.Data.Enums;
using System.Collections.Generic;

namespace SportData.Web.Models
{
    public class FootballTeamsCompareInfoDetailsViewModel
    {
        public MatchCompareType CompareType { get; set; }

        public List<FootballMatchViewModel> HostMatches { get; set; }

        public List<FootballMatchViewModel> VisitorMatches { get; set; }

        public List<FootballMatchViewModel> BetweenMatches { get; set; }
    }
}