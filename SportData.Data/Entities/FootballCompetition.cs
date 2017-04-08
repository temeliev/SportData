using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportData.Data.Entities
{
    [Table("FootballCompetitions")]
    public class FootballCompetition
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        [Column(TypeName = "nvarchar")]
        public string Name { get; set; }

        public int? OriginalCompetitionId { get; set; }

        public int LocationId { get; set; }

        public string CompetitionImageUrl { get; set; }

        public bool IsActive { get; set; }

        public virtual FootballCompetition OriginalCompetition { get; set; }

        public virtual Location Location { get; set; }

        public virtual ICollection<FootballCompetitionCulture> Cultures { get; set; }

        public virtual ICollection<Match> Matches { get; set; }
    }
}
