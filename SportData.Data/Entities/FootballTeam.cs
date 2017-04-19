using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportData.Data.Entities
{
    [Table("FootballTeams")]
    public class FootballTeam
    {
        [Key]
        public int Id { get; set; }

        public int? OriginalTeamId { get; set; }

        public string EmblemImageUrl { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        [MaxLength(250)]
        [Column(TypeName = "nvarchar")]
        public string Name { get; set; }

        public int LocationId { get; set; }

        public DateTime? CDate { get; set; }

        public virtual FootballTeam OriginalTeam { get; set; }

        public virtual Location Location { get; set; }

        public virtual ICollection<FootballTeamCulture> Cultures { get; set; }

        [InverseProperty("HomeTeam")]
        public virtual ICollection<Match> HomeTeamMatches { get; set; }

        [InverseProperty("AwayTeam")]
        public virtual ICollection<Match> AwayTeamMatches { get; set; }

        public virtual ICollection<MatchEvent> MatchEvents { get; set; }

        public virtual ICollection<FootballTeamPlayer> Players { get; set; }

        //public virtual ICollection<FootballPlayer> PlayersTest { get; set; }
    }
}
