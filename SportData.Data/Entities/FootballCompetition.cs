using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportData.Data.Entities
{
    [Table("FootballCompetitions")]
    public class FootballCompetition
    {
        public FootballCompetition()
        {
            this.Cultures = new HashSet<FootballCompetitionCulture>();
            this.Matches = new HashSet<Match>();
        }

        [Key]
        public int Id { get; set; }

        public int? OriginalCompetitionId { get; set; }

        public int LocationId { get; set; }

        public string CompetitionImageUrl { get; set; }

        public bool IsActive { get; set; }

        public virtual FootballCompetition OriginalCompetition { get; set; }

        public virtual Location Location { get; set; }

        public ICollection<FootballCompetitionCulture> Cultures { get; set; }

        public ICollection<Match> Matches { get; set; }
    }
}
