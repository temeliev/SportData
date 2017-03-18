using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportData.Data.Entities
{
    [Table("MatchEvents")]
    public class MatchEvent
    {
        [Key]
        public int Id { get; set; }

        public long MatchId { get; set; }

        public int TeamId { get; set; }

        public int EventTypeId { get; set; }

        public int? MainPlayerId { get; set; }

        public int? SecondaryPlayerId { get; set; }

        [MaxLength(10)]
        [Column(TypeName = "nchar")]
        public string Minute { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CDate { get; set; }

        public virtual Match Match { get; set; }

        public virtual FootballTeam Team { get; set; }

        public virtual FootballPlayer MainPlayer { get; set; }

        public virtual FootballPlayer SecondaryPlayer { get; set; }

        public virtual EventType EventType { get; set; }
    }
}
