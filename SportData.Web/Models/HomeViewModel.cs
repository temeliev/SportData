using System;
using System.Collections.Generic;

namespace SportData.Web.Models
{
    public class HomeViewModel
    {
        public DateTime CurrentDate { get; set; }

        public string SelectedDate { get; set; }

        public List<GroupedMatchesViewModel> GroupedMatches { get; set; }

        public List<LocationViewModel> Countries { get; set; }

        public List<LocationViewModel> OtherCompetitions { get; set; }
    }
}