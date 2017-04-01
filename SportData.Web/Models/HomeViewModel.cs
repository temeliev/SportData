using System;
using System.Collections.Generic;

namespace SportData.Web.Models
{
    public class HomeViewModel
    {
        public DateTime CurrentDate { get; set; }

        public List<MatchViewModel> Matches { get; set; }

        public List<LocationViewModel> Countries { get; set; }

        public List<LocationViewModel> OtherCompetitions { get; set; }
    }
}