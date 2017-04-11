using System.Web.Mvc;
using SportData.Web.Interfaces;
using SportData.Web.Models.Admin;
using SportData.Web.Services;

namespace SportData.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetCountries()
        {
            var countries = _adminService.GetCountries();
            return View(countries);
        }

        [HttpGet]
        public ActionResult GetCompetitions()
        {
            var competitionVm = _adminService.GetCompetitions();
            return View(competitionVm);
        }

        #region Location

        [HttpGet]
        public ActionResult AddCountry()
        {
            CountryViewModel countryVm = new CountryViewModel();
            ViewBag.Locations = _adminService.GetMainLocations();
            ViewBag.Cultures = _adminService.GetCultures();

            return View("AddCountry", countryVm);
        }

        [HttpPost]
        public ActionResult AddCountry(CountryViewModel model)
        {
            int countryId = _adminService.AddCountry(model);

            return EditCountry(countryId);
        }

        [HttpGet]
        public ActionResult EditCountry(int countryId)
        {
            var countryVm = _adminService.GetCountryViewById(countryId);
            ViewBag.Locations = _adminService.GetMainLocations();
            ViewBag.Cultures = _adminService.GetCultures();

            return View("EditCountry", countryVm);
        }

        [HttpPost]
        public ActionResult EditCountry([Bind(Include = "Id, Name, LocationImageUrl, Abbreviation, ParentId")]CountryViewModel model)
        {
            _adminService.UpdateCountry(model);

            var countryVm = _adminService.GetCountryViewById(model.Id);
            ViewBag.Locations = _adminService.GetMainLocations();
            ViewBag.Cultures = _adminService.GetCultures();

            return View("EditCountry", countryVm);
        }

        [HttpGet]
        public ActionResult DeleteCountry(int countryId)
        {
            _adminService.DeleteCountry(countryId);

            var countries = _adminService.GetCountries();

            return View("GetCountries", countries);
        }

        [HttpGet]
        public ActionResult AddCountryCulture(int countryId)
        {
            CountryCultureViewModel countryCultureVm = new CountryCultureViewModel();
            countryCultureVm.CountryId = countryId;

            ViewBag.Cultures = _adminService.GetCultures();

            return View(countryCultureVm);
        }

        [HttpPost]
        public ActionResult AddCountryCulture([Bind(Include = "CountryId, CountryName, CultureId")]CountryCultureViewModel model)
        {
            _adminService.AddCountryCulture(model);

            return EditCountry(model.CountryId);
        }

        [HttpGet]
        public ActionResult EditCountryCulture(int countryId, int cultureId)
        {
            CountryCultureViewModel countryVm = _adminService.GetCountryCultureViewById(countryId, cultureId);

            return View(countryVm);
        }

        [HttpPost]
        public ActionResult EditCountryCulture([Bind(Include = "CountryId, CountryName, CultureId")]CountryCultureViewModel model)
        {
            _adminService.UpdateCountryCulture(model);

            return EditCountry(model.CountryId);
        }

        [HttpGet]
        public ActionResult DeleteCountryCulture(int countryId, int cultureId)
        {
            _adminService.DeleteCountryCulture(countryId, cultureId);
            return EditCountry(countryId);
        }

        #endregion Location

        #region Competition

        public ActionResult AddCompetition()
        {
            CompetitionViewModel competitionVm = new CompetitionViewModel();
            ViewBag.Locations = _adminService.GetAllLocations();

            return View("AddCompetition", competitionVm);
        }

        [HttpPost]
        public ActionResult AddCompetition(CompetitionViewModel model)
        {
            int competitionId = _adminService.AddCompetition(model);

            return EditCompetition(competitionId);
        }

        [HttpGet]
        public ActionResult EditCompetition(int competitionId)
        {
            var competitionVm = _adminService.GetCompetitionViewById(competitionId);
            ViewBag.Locations = _adminService.GetAllLocations();

            return View("EditCompetition", competitionVm);
        }

        [HttpPost]
        public ActionResult EditCompetition([Bind(Include = "Id, Name, CompetitionImageUrl, IsActive, LocationId, OriginalCompetitionId")]CompetitionViewModel model)
        {
            _adminService.UpdateCompetition(model);

            return EditCompetition(model.Id);
        }

        [HttpGet]
        public ActionResult DeleteCompetition(int competitionId)
        {
            _adminService.DeleteCompetition(competitionId);

            var competitionVm = _adminService.GetCompetitions();

            return View("GetCompetitions", competitionVm);
        }

        [HttpGet]
        public ActionResult AddCompetitionCulture(int competitionId)
        {
            CompetitionCultureViewModel competitionCultureVm = new CompetitionCultureViewModel();
            competitionCultureVm.CompetitionId = competitionId;

            ViewBag.Cultures = _adminService.GetCultures();

            return View(competitionCultureVm);
        }

        [HttpPost]
        public ActionResult AddCompetitionCulture([Bind(Include = "CompetitionId, CompetitionName, CultureId")]CompetitionCultureViewModel model)
        {
            _adminService.AddCompetitionCulture(model);

            return EditCompetition(model.CompetitionId);
        }

        [HttpGet]
        public ActionResult EditCompetitionCulture(int competitionId, int cultureId)
        {
            CompetitionCultureViewModel competitionCultureVm = _adminService.GetCompetitionCultureViewById(competitionId, cultureId);

            return View(competitionCultureVm);
        }

        [HttpPost]
        public ActionResult EditCompetitionCulture([Bind(Include = "CompetitionId, CompetitionName, CultureId")]CompetitionCultureViewModel model)
        {
            _adminService.UpdateCompetitionCulture(model);

            return View();
        }

        [HttpGet]
        public ActionResult DeleteCompetitionCulture(int competitionId, int cultureId)
        {
            _adminService.DeleteCompetitionCulture(competitionId, cultureId);

            return EditCompetition(competitionId);
        }

        #endregion
    }
}