using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportData.Web.Models
{
    using SportData.Data.Enums;

    public class FootballLeagueRankingInfoViewModel
    {
        public int CompetitionId { get; set; }

        public RankingType RankingType { get; set; }

        public Dictionary<string, List<FootballLeagueRankingViewModel>> Ranking { get; set; }
    }
}