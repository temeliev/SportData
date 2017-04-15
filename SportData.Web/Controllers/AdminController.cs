using System.Web.Mvc;
using SportData.Data.Enums;
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

        #region Location

        [HttpGet]
        public ActionResult Countries()
        {
            var countries = _adminService.GetCountries();
            return View(countries);
        }

        [HttpGet]
        public ActionResult AddCountry()
        {
            CountryViewModel countryVm = new CountryViewModel();
            ViewBag.Locations = _adminService.GetLocations(LocationType.Continent);
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
            ViewBag.Locations = _adminService.GetLocations(LocationType.Country);
            ViewBag.Cultures = _adminService.GetCultures();

            return View("EditCountry", countryVm);
        }

        [HttpPost]
        public ActionResult EditCountry([Bind(Include = "Id, Name, LocationImageUrl, Abbreviation, ParentId")]CountryViewModel model)
        {
            _adminService.UpdateCountry(model);

            var countryVm = _adminService.GetCountryViewById(model.Id);
            ViewBag.Locations = _adminService.GetLocations(LocationType.Continent);
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

        [HttpGet]
        public ActionResult Competitions()
        {
            var competitionVm = _adminService.GetCompetitions();
            return View(competitionVm);
        }

        public ActionResult AddCompetition()
        {
            CompetitionViewModel competitionVm = new CompetitionViewModel();
            ViewBag.Locations = _adminService.GetLocations(LocationType.All);

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
            ViewBag.Locations = _adminService.GetLocations(LocationType.All);

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

        #region Player

        [HttpGet]
        public ActionResult FootballPlayers()
        {
            var footballPlayerVm = _adminService.GetFootballPlayers();
            return View(footballPlayerVm);
        }

        [HttpGet]
        public ActionResult AddFootballPlayer()
        {
            FootballPlayerViewModel footballPlayerVm = new FootballPlayerViewModel();
            ViewBag.Locations = _adminService.GetLocations(LocationType.Country);

            return View("AddFootballPlayer", footballPlayerVm);
        }

        [HttpPost]
        public ActionResult AddFootballPlayer(FootballPlayerViewModel model)
        {
            int playerId = _adminService.AddFootballPlayer(model);

            return RedirectToAction("EditFootballPlayer", new { footballPlayerId = playerId });
        }

        [HttpGet]
        public ActionResult EditFootballPlayer(int footballPlayerId)
        {
            var footballPlayerVm = _adminService.GetFootballPlayerViewById(footballPlayerId);
            ViewBag.Locations = _adminService.GetLocations(LocationType.Country);

            return View("EditFootballPlayer", footballPlayerVm);
        }

        [HttpPost]
        public ActionResult EditFootballPlayer([Bind(Include = "Id, FirstName, SecondName, LastName, DateOfBirth, NationalityId, PlayerImageUrl")]FootballPlayerViewModel model)
        {
            _adminService.UpdateFootballPlayer(model);

            return EditFootballPlayer(model.Id);
        }

        [HttpGet]
        public ActionResult DeleteFootballPlayer(int footballPlayerId)
        {
            _adminService.DeleteFootballPlayer(footballPlayerId);

            var footballPlayerVm = _adminService.GetFootballPlayers();

            return View("FootballPlayers", footballPlayerVm);
        }

        [HttpGet]
        public ActionResult AddFootballPlayerCulture(int footballPlayerId)
        {
            FootballPlayerCultureViewModel footballPlayerCultureVm = new FootballPlayerCultureViewModel();
            footballPlayerCultureVm.FootballPlayerId = footballPlayerId;

            ViewBag.Cultures = _adminService.GetCultures();

            return View(footballPlayerCultureVm);
        }

        [HttpPost]
        public ActionResult AddFootballPlayerCulture([Bind(Include = "FootballPlayerId, FirstName, SecondName, LastName, CultureId")]FootballPlayerCultureViewModel model)
        {
            _adminService.AddFootballPlayerCulture(model);

            return RedirectToAction("EditFootballPlayer", new { footballPlayerId = model.FootballPlayerId });
        }

        [HttpGet]
        public ActionResult EditFootballPlayerCulture(int footballPlayerId, int cultureId)
        {
            FootballPlayerCultureViewModel footballPlayerCultureVm = _adminService.GetFootballPlayerCultureViewById(footballPlayerId, cultureId);

            return View(footballPlayerCultureVm);
        }

        [HttpPost]
        public ActionResult EditFootballPlayerCulture([Bind(Include = "FootballPlayerId, FirstName, SecondName, LastName, CultureId")]FootballPlayerCultureViewModel model)
        {
            _adminService.UpdateFootballPlayerCulture(model);

            return RedirectToAction("EditFootballPlayerCulture", new { footballPlayerId = model.FootballPlayerId, cultureId = model.CultureId });
        }

        [HttpGet]
        public ActionResult DeleteFootballPlayerCulture(int footballPlayerId, int cultureId)
        {
            _adminService.DeleteFootballCulture(footballPlayerId, cultureId);

            return RedirectToAction("EditFootballPlayer", new { footballPlayerId = footballPlayerId });
        }

        #endregion
    }
}