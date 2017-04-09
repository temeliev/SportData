using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportData.Data.Entities
{
    [Table("FootballTeamPlayers")]
    public class FootballTeamPlayer
    {
        [Key]
        public int Id { get; set; }

        public int TeamId { get; set; }

        public int PlayerId { get; set; }

        public bool IsActive { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime? CDate { get; set; }

        public virtual FootballTeam Team { get; set; }

        public virtual FootballPlayer Player { get; set; }
    }
}
