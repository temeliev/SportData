using System.Web.Mvc;
using SportData.Web.Interfaces;
using SportData.Web.Models.Admin;
using SportData.Web.Services;

namespace SportData.Web.Controllers
{
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
            ViewBag.Locations = _service.GetMainLocations();
            ViewBag.Cultures = _service.GetCultures();
             
            return View("AddCountry", countryVm);
        }

        [HttpPost]
        public ActionResult AddCountry(CountryViewModel model)
        {
            int countryId = _service.AddCountry(model);
            var countryVm = _service.GetCountryViewById(countryId);
            ViewBag.Locations = _service.GetMainLocations();
            ViewBag.Cultures = _service.GetCultures();

            return View("EditCountry", countryVm);
        }

        [HttpGet]
        public ActionResult EditCountry(int countryId)
        {
            var countryVm = _service.GetCountryViewById(countryId);
            ViewBag.Locations = _service.GetMainLocations();
            ViewBag.Cultures = _service.GetCultures();

            return View("EditCountry", countryVm);
        }

        [HttpPost]
        public ActionResult EditCountry([Bind(Include = "Id, Name, LocationImageUrl, Abbreviation, ParentId")]CountryViewModel model)
        {
            _service.UpdateCountry(model);

            var countryVm = _service.GetCountryViewById(model.Id);
            ViewBag.Locations = _service.GetMainLocations();
            ViewBag.Cultures = _service.GetCultures();

            return View("EditCountry", countryVm);
        }

        [HttpGet]
        public ActionResult DeleteCountry(int countryId)
        {
            _service.DeleteCountry(countryId);
            var countries = _service.GetCountries();
            return View("Countries", countries);
        }

        [HttpGet]
        public ActionResult AddCountryCulture(int countryId)
        {
            CountryCultureViewModel countryCultureVm = new CountryCultureViewModel();
            countryCultureVm.CountryId = countryId;
             
            ViewBag.Cultures = _service.GetCultures();
            
            return View(countryCultureVm);
        }

        [HttpPost]
        public ActionResult AddCountryCulture([Bind(Include = "CountryId, CountryName, CultureId")]CountryCultureViewModel model)
        {
            _service.AddCountryCulture(model);
            var countryVm = _service.GetCountryViewById(model.CountryId);
            ViewBag.Locations = _service.GetMainLocations();
            ViewBag.Cultures = _service.GetCultures();

            return View("EditCountry", countryVm);
        }

        [HttpGet]
        public ActionResult EditCountryCulture(int countryId, int cultureId)
        {
            CountryCultureViewModel countryVm = _service.GetCountryCultureViewById(countryId, cultureId);

            return View(countryVm);
        }

        [HttpPost]
        public ActionResult EditCountryCulture(CountryCultureViewModel model)
        {
            _service.UpdateCountryCulture(model);
            var countryVm = _service.GetCountryViewById(model.CountryId);
            ViewBag.Locations = _service.GetMainLocations();
            ViewBag.Cultures = _service.GetCultures();

            return View("EditCountry", countryVm);
        }

        [HttpGet]
        public ActionResult DeleteCountryCulture(int countryId, int cultureId)
        {
            _service.DeleteCountryCulture(countryId, cultureId);
            var countries = _service.GetCountries();
            return View("Countries", countries);
        }
    }
}