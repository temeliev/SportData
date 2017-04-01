using System.Web.Mvc;
using SportData.Web.Interfaces;
using SportData.Web.Models.Admin;
using SportData.Web.Services;

namespace SportData.Web.Controllers
{
    [OutputCache(Duration = 10, VaryByParam = "none")]
    public class AdminController : Controller
    {
        private readonly AdminService _service;

        public AdminController(IUnitOfWork unitOfWork)
        {
            _service = new AdminService(unitOfWork);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Countries()
        {
            var countries = _service.GetCountries();
            return View(countries);
        }

        [HttpGet]
        public ActionResult Competitions()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddCountry()
        {
            CountryViewModel countryVm = new CountryViewModel();
            countryVm.Locations = _service.GetMainLocations();
            countryVm.Cultures = _service.GetCultures();
            return View("Country", countryVm);
        }

        [HttpPost]
        public ActionResult AddCountry(CountryViewModel model)
        {
            return View("Country");
        }

        [HttpGet]
        public ActionResult EditCountry()
        {
            return View("Country");
        }

        [HttpPost]
        public ActionResult EditCountry(CountryViewModel model)
        {
            return View("Country");
        }

        [HttpPost]
        public ActionResult DeleteCountry(int countryId)
        {
            return View("Country");
        }
    }
}