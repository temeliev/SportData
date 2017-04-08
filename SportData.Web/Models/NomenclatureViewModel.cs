using System.Collections.Generic;
using System.Web.Mvc;

namespace SportData.Web.Models
{
    public class NomenclatureViewModel
    {
        public List<SelectListItem> Locations { get; set; }

        public List<SelectListItem> Cultures { get; set; }
    }
}