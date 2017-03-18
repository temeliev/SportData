using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportData.Data.Entities
{
    [Table("FootballTeams")]
    public class FootballTeam
    {
        public FootballTeam()
        {
            this.Cultures = new HashSet<FootballTeamCulture>();
            this.HomeTeamMatches = new HashSet<Match>();
            this.AwayTeamMatches = new HashSet<Match>();
            this.MatchEvents = new HashSet<MatchEvent>();
            this.PlayersHistory = new HashSet<FootballTeamPlayer>();
        }

        [Key]
        public int Id { get; set; }

        public int? OriginalTeamId { get; set; }

        public string EmblemImageUrl { get; set; }

        public bool IsActive { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CDate { get; set; }

        public virtual FootballTeam OriginalTeam { get; set; }

        public ICollection<FootballTeamCulture> Cultures { get; set; }

        [InverseProperty("HomeTeam")]
        public ICollection<Match> HomeTeamMatches { get; set; }

        [InverseProperty("AwayTeam")]
        public ICollection<Match> AwayTeamMatches { get; set; }

        public ICollection<MatchEvent> MatchEvents { get; set; }

        public ICollection<FootballTeamPlayer> PlayersHistory { get; set; }
    }
}
