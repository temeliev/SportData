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
        public ActionResult GetCountries()
        {
            var countries = _service.GetCountries();
            return View(countries);
        }

        [HttpGet]
        public ActionResult GetCompetitions()
        {
            var competitionVm = _service.GetCompetitions();
            return View(competitionVm);
        }

        #region Location

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

            return EditCountry(countryId);
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

            return View("GetCountries", countries);
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

            return EditCountry(model.CountryId);
        }

        [HttpGet]
        public ActionResult EditCountryCulture(int countryId, int cultureId)
        {
            CountryCultureViewModel countryVm = _service.GetCountryCultureViewById(countryId, cultureId);

            return View(countryVm);
        }

        [HttpPost]
        public ActionResult EditCountryCulture([Bind(Include = "CountryId, CountryName, CultureId")]CountryCultureViewModel model)
        {
            _service.UpdateCountryCulture(model);
             
            return EditCountry(model.CountryId);
        }

        [HttpGet]
        public ActionResult DeleteCountryCulture(int countryId, int cultureId)
        {
            _service.DeleteCountryCulture(countryId, cultureId);
            return EditCountry(countryId);
        }

        #endregion Location

        #region Competition

        public ActionResult AddCompetition()
        {
            CompetitionViewModel competitionVm = new CompetitionViewModel();
            ViewBag.Locations = _service.GetAllLocations();
            
            return View("AddCompetition", competitionVm);
        }

        [HttpPost]
        public ActionResult AddCompetition(CompetitionViewModel model)
        {
            int competitionId = _service.AddCompetition(model);
             
            return EditCompetition(competitionId);
        }

        [HttpGet]
        public ActionResult EditCompetition(int competitionId)
        {
            var competitionVm = _service.GetCompetitionViewById(competitionId);
            ViewBag.Locations = _service.GetAllLocations();

            return View("EditCompetition", competitionVm);
        }

        [HttpPost]
        public ActionResult EditCompetition([Bind(Include = "Id, Name, CompetitionImageUrl, IsActive, LocationId, OriginalCompetitionId")]CompetitionViewModel model)
        {
            _service.UpdateCompetition(model);

            return EditCompetition(model.Id);
        }

        [HttpGet]
        public ActionResult DeleteCompetition(int competitionId)
        {
            _service.DeleteCompetition(competitionId);

            var competitionVm = _service.GetCompetitions();

            return View("GetCompetitions", competitionVm);
        }

        [HttpGet]
        public ActionResult AddCompetitionCulture(int competitionId)
        {
            CompetitionCultureViewModel competitionCultureVm = new CompetitionCultureViewModel();
            competitionCultureVm.CompetitionId = competitionId;

            ViewBag.Cultures = _service.GetCultures();

            return View(competitionCultureVm);
        }

        [HttpPost]
        public ActionResult AddCompetitionCulture([Bind(Include = "CompetitionId, CompetitionName, CultureId")]CompetitionCultureViewModel model)
        {
            _service.AddCompetitionCulture(model);
             
            return EditCompetition(model.CompetitionId);
        }

        [HttpGet]
        public ActionResult EditCompetitionCulture(int competitionId, int cultureId)
        {
            CompetitionCultureViewModel competitionCultureVm = _service.GetCompetitionCultureViewById(competitionId, cultureId);

            return View(competitionCultureVm);
        }

        [HttpPost]
        public ActionResult EditCompetitionCulture([Bind(Include = "CompetitionId, CompetitionName, CultureId")]CompetitionCultureViewModel model)
        {
            _service.UpdateCompetitionCulture(model);
            
            return View();
        }

        [HttpGet]
        public ActionResult DeleteCompetitionCulture(int competitionId, int cultureId)
        {
            _service.DeleteCompetitionCulture(competitionId, cultureId);
             
            return EditCompetition(competitionId);
        }

        #endregion
    }
}