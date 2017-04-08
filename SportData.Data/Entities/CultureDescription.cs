using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportData.Data.Entities
{
    [Table("CultureDescription")]
    public class CultureDescription
    {
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

        public virtual ICollection<LocationCulture> LocationCultures { get; set; }

        public virtual ICollection<FootballCompetitionCulture> FootballCompetitionCultures { get; set; }

        public virtual ICollection<FootballPlayerCulture> FootballPlayerCultures { get; set; }

        public virtual ICollection<FootballTeamCulture> FootballTeamCultures { get; set; }

        public virtual ICollection<MatchStatusCulture> MatchStatusCultures { get; set; }
    }
}
