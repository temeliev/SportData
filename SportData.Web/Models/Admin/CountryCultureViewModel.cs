using System.ComponentModel.DataAnnotations;

namespace SportData.Web.Models.Admin
{
    public class CountryCultureViewModel : BaseViewModel
    {
        public int CountryId { get; set; }

        [Display(Name = "CountryName", ResourceType = typeof(Resources.Admin.Country))]
        [Required(ErrorMessageResourceType = typeof(Resources.Admin.Country),
                  ErrorMessageResourceName = "CountryNameErrorMsg")]
        public string CountryName { get; set; }

        [Display(Name = "CultureName", ResourceType = typeof(Resources.Admin.Country))]
        [Required(ErrorMessageResourceType = typeof(Resources.Admin.Country),
                  ErrorMessageResourceName = "CultureIdErrorMsg")]
        public int CultureId { get; set; }

        [Display(Name = "CultureName", ResourceType = typeof(Resources.Admin.Country))]
        public string CultureName { get; set; }
    }
}