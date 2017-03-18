using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportData.Data.Entities
{
    [Table("FootballPlayers")]
    public class FootballPlayer
    {
        public FootballPlayer()
        {
            this.MainPlayerEvents = new HashSet<MatchEvent>();
            this.SecondaryPlayerEvents = new HashSet<MatchEvent>();
            this.TeamsHistory = new HashSet<FootballTeamPlayer>();
        }

        [Key]
        public int Id { get; set; }

        public int NationalityId { get; set; }

        public string PlayerImageUrl { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CDate { get; set; }

        public virtual Location Nationality { get; set; }

        [InverseProperty("MainPlayer")]
        public ICollection<MatchEvent> MainPlayerEvents { get; set; }

        [InverseProperty("SecondaryPlayer")]
        public ICollection<MatchEvent> SecondaryPlayerEvents { get; set; }

        public ICollection<FootballTeamPlayer> TeamsHistory { get; set; }
    }
}
