using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportData.Data.Entities
{
    [Table("FootballCompetitionCultures")]
    public class FootballCompetitionCulture
    {
        [Column(Order = 0), Key]
        public int CompetitionId { get; set; }

        [Column(Order = 1), Key]
        public string Culture { get; set; }

        [Required]
        [MaxLength(250)]
        [Column(TypeName = "nvarchar")]
        public string Name { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CDate { get; set; }

        public virtual FootballCompetition Competition { get; set; }
    }
}
