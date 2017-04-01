using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SportData.Web.Models.Admin
{
    public class CountryViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Име")]
        public string CountryName { get; set; }

        public int? ParentId { get; set; }

        public string LocationName { get; set; }

        public string LocationImageUrl { get; set; }

        public string Abbreviation { get; set; }

        public int CultureId { get; set; }

        public string CultureName { get; set; }

        public List<SelectListItem> Locations { get; set; }

        public List<SelectListItem> Cultures { get; set; }
    }
}