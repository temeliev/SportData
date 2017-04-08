using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportData.Data.Entities
{
    [Table("EventTypes")]
    public class EventType
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<MatchEvent> MatchEvents { get; set; }
    }
}
