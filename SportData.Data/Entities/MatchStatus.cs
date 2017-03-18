using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportData.Data.Entities
{
    [Table("MatchStatuses")]
    public class MatchStatus
    {
        public MatchStatus()
        {
            this.Matches = new HashSet<Match>();
            this.Cultures = new HashSet<MatchStatusCulture>();
        }

        [Key]
        public int Id { get; set; }

        public bool IsActive { get; set; }

        public ICollection<MatchStatusCulture> Cultures { get; set; }

        public ICollection<Match> Matches { get; set; }
    }
}
