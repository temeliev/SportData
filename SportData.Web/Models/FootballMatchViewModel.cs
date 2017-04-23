using System;

namespace SportData.Web.Models
{
    public class FootballMatchViewModel
    {
        public long MatchId { get; set; }

        public string StartHour => MatchDate.Hour + ":" + (MatchDate.Minute < 10 ? "0" + MatchDate.Minute : MatchDate.Minute.ToString());

        public DateTime MatchDate { get; set; }

        public int MatchStatusId { get; set; }

        public string MatchStatusName { get; set; }

        public string HomeTeamName { get; set; }

        public string AwayTeamName { get; set; }

        public string MatchResult { get; set; }

        public int CompetitionId { get; set; }

        public string CompetitionName { get; set; }
    }
}