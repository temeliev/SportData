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

        [Display(Name = "Име", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessage = "Липсва име на държавата!")]
        public string Name { get; set; }

        public int? ParentId { get; set; }

        [Display(Name = "Локация")]
        public string LocationName { get; set; }

        [Display(Name = "Линк")]
        public string LocationImageUrl { get; set; }

        [Display(Name = "Съкращение")]
        public string Abbreviation { get; set; }

        public List<CountryCultureViewModel> Cultures { get; set; }
    }
}