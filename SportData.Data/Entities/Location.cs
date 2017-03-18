using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportData.Data.Entities
{
    [Table("Locations")]
    public class Location
    {
        public Location()
        {
            this.Cultures = new HashSet<LocationCulture>();
            this.Competitions = new HashSet<FootballCompetition>();
            this.AddressInfoCollection = new HashSet<AddressInfo>();
            this.Players = new HashSet<FootballPlayer>();
        }

        public int Id { get; set; }

        public int? ParentId { get; set; }

        public string LocationImageUrl { get; set; }

        public string Abbreviation { get; set; }

        public virtual Location Parent { get; set; }

        public ICollection<LocationCulture> Cultures { get; set; }

        public ICollection<FootballCompetition> Competitions { get; set; }

        public ICollection<AddressInfo> AddressInfoCollection { get; set; }

        public ICollection<FootballPlayer> Players { get; set; }
    }
}
