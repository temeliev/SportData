using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportData.Web.Models
{
    public class FootballLeagueInfoViewModel
    {
        public FootballLeagueRankingInfoViewModel LeagueRankingInfo { get; set; }

        public List<LocationViewModel> Countries { get; set; }
    }
}