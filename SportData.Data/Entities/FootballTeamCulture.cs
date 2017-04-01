using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportData.Data.Entities
{
    [Table("FootballTeamCultures")]
    public class FootballTeamCulture
    {
        [Column(Order = 0), Key]
        public int TeamId { get; set; }

        [Column(Order = 1), Key]
        public int CultureId { get; set; }

        [Required]
        [MaxLength(250)]
        [Column(TypeName = "nvarchar")]
        public string Name { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CDate { get; set; }

        public virtual FootballTeam Team { get; set; }

        public virtual CultureDescription Culture { get; set; }
    }
}
