using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SportData.Web.Models.Admin
{
    public class CountryViewModel : BaseViewModel
    {
        public CountryViewModel()
        {
            this.Cultures = new List<CountryCultureViewModel>();
        }

        public int Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Resources.Admin.Country))]
        [Required(ErrorMessageResourceType = typeof(Resources.Admin.Country),
                  ErrorMessageResourceName = "NameErrorMsg")]
        public string Name { get; set; }

        [Display(Name = "Continent", ResourceType = typeof(Resources.Admin.Country))]
        [Required(ErrorMessageResourceType = typeof(Resources.Admin.Country),
                  ErrorMessageResourceName = "ParentIdErrorMsg")]
        public int? ParentId { get; set; }

        [Display(Name = "Continent", ResourceType = typeof(Resources.Admin.Country))]
        public string LocationName { get; set; }

        [Display(Name = "LocationImageUrl", ResourceType = typeof(Resources.Admin.Country))]
        public string LocationImageUrl { get; set; }

        [Display(Name = "Abbreviation", ResourceType = typeof(Resources.Admin.Country))]
        public string Abbreviation { get; set; }

        public List<CountryCultureViewModel> Cultures { get; set; }
    }
}