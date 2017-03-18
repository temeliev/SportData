using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportData.Data.Entities
{
    [Table("FootballPlayerCultures")]
    public class FootballPlayerCulture
    {
        [Column(Order = 0), Key]
        public int PlayerId { get; set; }

        [Column(Order = 1), Key]
        public string Culture { get; set; }

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

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CDate { get; set; }

        public virtual FootballPlayer Player { get; set; }
    }
}
