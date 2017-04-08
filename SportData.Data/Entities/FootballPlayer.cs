using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportData.Data.Entities
{
    [Table("FootballPlayers")]
    public class FootballPlayer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        [Column(TypeName = "nvarchar")]
        public string FirstName { get; set; }

        [MaxLength(250)]
        [Column(TypeName = "nvarchar")]
        public string SecondName { get; set; }

        [Required]
        [MaxLength(250)]
        [Column(TypeName = "nvarchar")]
        public string LastName { get; set; }

        public int NationalityId { get; set; }

        public string PlayerImageUrl { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CDate { get; set; }

        public virtual Location Nationality { get; set; }

        [InverseProperty("MainPlayer")]
        public virtual ICollection<MatchEvent> MainPlayerEvents { get; set; }

        [InverseProperty("SecondaryPlayer")]
        public virtual ICollection<MatchEvent> SecondaryPlayerEvents { get; set; }

        public virtual ICollection<FootballTeamPlayer> TeamsHistory { get; set; }
    }
}
