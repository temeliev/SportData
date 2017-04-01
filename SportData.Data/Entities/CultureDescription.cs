using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportData.Data.Entities
{
    [Table("CultureDescription")]
    public class CultureDescription
    {
        public CultureDescription()
        {
            this.LocationCultures = new HashSet<LocationCulture>();
            this.FootballCompetitionCultures = new HashSet<FootballCompetitionCulture>();
            this.FootballPlayerCultures = new HashSet<FootballPlayerCulture>();
            this.FootballTeamCultures = new HashSet<FootballTeamCulture>();
            this.MatchStatusCultures = new HashSet<MatchStatusCulture>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Column(TypeName = "nvarchar")]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar")]
        public string ShowText { get; set; }

        public ICollection<LocationCulture> LocationCultures { get; set; }

        public ICollection<FootballCompetitionCulture> FootballCompetitionCultures { get; set; }

        public ICollection<FootballPlayerCulture> FootballPlayerCultures { get; set; }

        public ICollection<FootballTeamCulture> FootballTeamCultures { get; set; }

        public ICollection<MatchStatusCulture> MatchStatusCultures { get; set; }
    }
}
