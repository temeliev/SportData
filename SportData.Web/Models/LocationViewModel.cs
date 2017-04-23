using System.Collections.Generic;
using SportData.Web.Models.Admin;

namespace SportData.Web.Models
{
    public class LocationViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<CompetitionCultureViewModel> Competitions { get; set; }
    }
}