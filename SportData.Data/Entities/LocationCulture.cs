using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportData.Data.Entities
{
    [Table("LocationCultures")]
    public class LocationCulture
    {
        [Column(Order = 0), Key] //, ForeignKey("Location")
        public int LocationId { get; set; }

        [Column(Order = 1), Key]
        public int CultureId { get; set; }

        [Required]
        [MaxLength(250)]
        [Column(TypeName = "nvarchar")]
        public string Name { get; set; }

        public DateTime? CDate { get; set; }

        public virtual Location Location { get; set; }

        public virtual CultureDescription Culture { get; set; }
    }
}
