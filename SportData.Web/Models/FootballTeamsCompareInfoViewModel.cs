using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportData.Web.Models
{
    public class FootballTeamsCompareInfoViewModel
    {
        public long MatchId { get; set; }

        public DateTime MatchDate { get; set; }

        public string LongMatchDate
        {
            get
            {
                string year = MatchDate.Year.ToString();
                string month = MatchDate.Month < 10 ? "0" + MatchDate.Month : MatchDate.Month.ToString();
                string day = MatchDate.Day < 10 ? "0" + MatchDate.Day : MatchDate.Day.ToString();
                string hour = MatchDate.Hour < 10 ? "0" + MatchDate.Hour : MatchDate.Hour.ToString();
                string minute = MatchDate.Minute < 10 ? "0" + MatchDate.Minute : MatchDate.Minute.ToString();

                return string.Format("{0}/{1}/{2} {3}:{4}", day, month, year, hour, minute);
            }
        }

        public string MatchStatus { get; set; }

        public string Score { get; set; }

        public int HostTeamId { get; set; }

        public string HostTeamName { get; set; }

        public string HostTeamEmblemUrl { get; set; }

        public int VisitorTeamId { get; set; }

        public string VisitorTeamName { get; set; }

        public string VisitorTeamEmblemUrl { get; set; }
        //TODO Delete
        //public int HeadToHeadOverallHostTopRow { get; set; }

        //public int HeadToHeadOverallVisitorTopRow { get; set; }

        //public int HeadToHeadOverallBetweenTopRow { get; set; }

        //public int HeadToHeadHostTopRow { get; set; }

        //public int HeadToHeadVisitorTopRow { get; set; }

        //public int HeadToHeadHostBetweenTopRow { get; set; }

        //public int HeadToHeadVisitortBetweenTopRow { get; set; }

        //public List<LocationViewModel> Countries { get; set; }

        public FootballTeamsCompareInfoDetailsViewModel HeadToHeadMatchesDetails { get; set; }
    }
}