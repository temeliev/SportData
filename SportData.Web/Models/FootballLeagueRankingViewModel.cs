namespace SportData.Web.Models
{
    using System.Collections.Generic;

    public class FootballLeagueRankingViewModel
    {
        public int TeamId { get; set; }

        public string TeamName { get; set; }

        public string TeamImageUrl { get; set; }

        public int Position { get; set; }

        public int PlayedMatchesAtHome { get; set; }

        public int PlayedMatchesAway { get; set; }

        public int PlayedMatchesCount => this.PlayedMatchesAtHome + this.PlayedMatchesAway;

        public int Wins => this.HomeWins + this.AwayWins;

        public int HomeWins { get; set; }

        public int AwayWins { get; set; }

        public int Draws => this.HomeDraws + this.AwayDraws;

        public int HomeDraws { get; set; }

        public int AwayDraws { get; set; }

        public int Losses => this.HomeLosses + this.AwayLosses;

        public int HomeLosses { get; set; }

        public int AwayLosses { get; set; }

        public int HomeGoalScored { get; set; }

        public int AwayGoalScored { get; set; }

        public int HomeGoalReceived { get; set; }

        public int AwayGoalReceived { get; set; }

        public string GoalDifference
            => $"{this.HomeGoalScored + this.AwayGoalScored} - {this.HomeGoalReceived + this.AwayGoalReceived}";

        public string HomeGoalDifference
            => $"{this.HomeGoalScored} - {this.HomeGoalReceived}";

        public string AwayGoalDifference
            => $"{this.AwayGoalScored} - {this.AwayGoalReceived}";

        public int Points => (this.Wins * 3) + this.Draws;

        public int HomePoints => (this.HomeWins * 3) + this.HomeDraws;

        public int AwayPoints => (this.AwayWins * 3) + this.AwayDraws;

        public string Round { get; set; }

        public List<string> Form { get; set; }
    }
}