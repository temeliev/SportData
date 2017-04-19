using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportData.Data.Entities
{
    public class CompetitionType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        [Column(TypeName = "nvarchar")]
        public string Name { get; set; }

        public virtual ICollection<FootballCompetition> FootballCompetitions { get; set; }
    }
}
