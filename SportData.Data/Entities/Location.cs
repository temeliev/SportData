using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportData.Data.Entities
{
    [Table("Locations")]
    public class Location
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public string LocationImageUrl { get; set; }

        [MaxLength(250)]
        [Column(TypeName = "nvarchar")]
        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public virtual Location Parent { get; set; }

        public virtual ICollection<LocationCulture> Cultures { get; set; }

        public virtual ICollection<FootballCompetition> Competitions { get; set; }

        public virtual ICollection<AddressInfo> AddressInfoCollection { get; set; }

        public virtual ICollection<FootballPlayer> Players { get; set; }
    }
}
