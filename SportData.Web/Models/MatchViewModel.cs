namespace SportData.Web.Models
{
    public class MatchViewModel
    {
        public long Id { get; set; }

        public string StartHour { get; set; }

        public string MatchStatusName { get; set; }

        public string HomeTeamName { get; set; }

        public string AwayTeamName { get; set; }

        public string MatchResult { get; set; }

        public string CompetitionName { get; set; }

        public string CompetitionFlagUrl { get; set; }
    }
}