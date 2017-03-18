using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportData.Data.Entities
{
    [Table("Seasons")]
    public class Season
    {
        public Season()
        {
            this.Matches = new HashSet<Match>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        [Column(TypeName = "nvarchar")]
        public string Name { get; set; }

        public ICollection<Match> Matches { get; set; }
    }
}
