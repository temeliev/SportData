using System.ComponentModel.DataAnnotations;

namespace SportData.Web.Models.Admin
{
    public class CountryCultureViewModel
    {
        public int CountryId { get; set; }

        [Display(Name = "Име")]
        public string CountryName { get; set; }

        public int CultureId { get; set; }

        [Display(Name = "Език")]
        public string CultureName { get; set; }
    }
}