using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportData.Data.Entities
{
    [Table("MatchStatuses")]
    public class MatchStatus
    {
        [Key]
        public int Id { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<MatchStatusCulture> Cultures { get; set; }

        public virtual ICollection<Match> Matches { get; set; }
    }
}
