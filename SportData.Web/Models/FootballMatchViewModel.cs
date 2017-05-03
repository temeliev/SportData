using System;

namespace SportData.Web.Models
{
    public class FootballMatchViewModel
    {
        public long MatchId { get; set; }

        public string StartHour
            => (MatchDate.Hour < 10 ? "0" + MatchDate.Hour : MatchDate.Hour.ToString()) + ":" + (MatchDate.Minute < 10 ? "0" + MatchDate.Minute : MatchDate.Minute.ToString());

        public DateTime MatchDate { get; set; }

        public string ShortMatchDate
        {
            get
            {
                string year = MatchDate.Year.ToString();
                string month = MatchDate.Month < 10 ? "0" + MatchDate.Month : MatchDate.Month.ToString();
                string day = MatchDate.Day < 10 ? "0" + MatchDate.Day : MatchDate.Day.ToString();

                return string.Format("{0}/{1}/{2}", day, month, year);
            }
        }

        public int MatchStatusId { get; set; }

        public string MatchStatusName { get; set; }

        public string HomeTeamName { get; set; }

        public string AwayTeamName { get; set; }

        public string MatchResult { get; set; }

        public int CompetitionId { get; set; }

        public string CompetitionName { get; set; }

        public string CompetitionEmblemUrl { get; set; }

        public string MatchRound { get; set; }

        public string CompetitionLocationName { get; set; }

        public string CompetitionFullName => $"{CompetitionLocationName}: {CompetitionName} - Round {MatchRound ?? "0"}";
    }
}