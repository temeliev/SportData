﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportData.Data.Entities
{
    [Table("Matches")]
    public class Match
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("HomeTeam")]
        public int HomeTeamId { get; set; }

        [ForeignKey("AwayTeam")]
        public int AwayTeamId { get; set; }

        [Required]
        public DateTime MatchDate { get; set; }

        [ForeignKey("Competition")]
        public int CompetitionId { get; set; }

        [ForeignKey("Season")]
        public int SeasonId { get; set; }

        [ForeignKey("Status")]
        public int StatusId { get; set; }

        [Column(TypeName = "nchar")]
        [MaxLength(10)]
        public string Minute { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(20)]
        public string Round { get; set; }

        public DateTime? CDate { get; set; }

        public virtual FootballTeam HomeTeam { get; set; }

        public virtual FootballTeam AwayTeam { get; set; }

        public virtual FootballCompetition Competition { get; set; }

        public virtual MatchStatus Status { get; set; }

        public virtual Season Season { get; set; }

        public virtual ICollection<MatchEvent> Events { get; set; }
    }
}
