using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportData.Data.Entities
{
    [Table("PlayerStatuses")]
    public class PlayerStatus
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<FootballTeamPlayer> Players { get; set; }
    }
}
