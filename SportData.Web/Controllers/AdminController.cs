using System;
using System.Linq;
using System.Web.Mvc;
using SportData.Data.Enums;
using SportData.Web.Interfaces;
using SportData.Web.Models.Admin;
using SportData.Web.Services;

namespace SportData.Web.Controllers
{
    public class AdminController : BaseController
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
            countryVm.PreviousLink = this.Url.Action("Countries", "Admin", Request.Url.Scheme);
            ViewBag.Locations = _adminService.GetLocations(LocationType.Continent);
            ViewBag.Cultures = _adminService.GetCultures();

            return View("AddCountry", countryVm);
        }

        [HttpPost]
        public ActionResult AddCountry(CountryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Locations = _adminService.GetLocations(LocationType.Continent);
                model.PreviousLink = this.Url.Action("Countries", "Admin", Request.Url.Scheme);
                return View(model);
            }

            int countryId = _adminService.AddCountry(model);

            return RedirectToAction("EditCountry", new {countryId});
        }

        [HttpGet]
        public ActionResult EditCountry(int countryId)
        {
            var countryVm = _adminService.GetCountryViewById(countryId);
            countryVm.PreviousLink = this.Url.Action("Countries", "Admin", this.Request.Url.Scheme);
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
            CountryViewModel vm = _adminService.GetCountryViewById(countryId);
            vm.PreviousLink = this.Url.Action("Countries", "Admin", this.Request.Url.Scheme);

            return View(vm);
        }

        [HttpPost]
        public ActionResult DeleteCountry([Bind(Include = "Id, Name, LocationImageUrl, Abbreviation, ParentId")]CountryViewModel model)
        {
            _adminService.DeleteCountry(model.Id);

            return RedirectToAction("Countries");
        }

        [HttpGet]
        public ActionResult AddCountryCulture(int countryId)
        {
            CountryCultureViewModel countryCultureVm = new CountryCultureViewModel();
            countryCultureVm.CountryId = countryId;
            countryCultureVm.PreviousLink = this.Url.Action("EditCountry", "Admin", new { countryId }, this.Request.Url.Scheme);

            ViewBag.Cultures = _adminService.GetCultures();

            return View(countryCultureVm);
        }

        [HttpPost]
        public ActionResult AddCountryCulture([Bind(Include = "CountryId, CountryName, CultureId")]CountryCultureViewModel model)
        {
            _adminService.AddCountryCulture(model);

            return RedirectToAction("EditCountry", new { countryId = model.CountryId });// EditCountry(model.CountryId);
        }

        [HttpGet]
        public ActionResult EditCountryCulture(int countryId, int cultureId)
        {
            CountryCultureViewModel countryVm = _adminService.GetCountryCultureViewById(countryId, cultureId);
            countryVm.PreviousLink = this.Url.Action("EditCountry", "Admin", new { countryId }, this.Request.Url.Scheme);

            return View(countryVm);
        }

        [HttpPost]
        public ActionResult EditCountryCulture([Bind(Include = "CountryId, CountryName, CultureId")]CountryCultureViewModel model)
        {
            _adminService.UpdateCountryCulture(model);

            return RedirectToAction("EditCountry", new { countryId = model.CountryId }); //EditCountry(model.CountryId);
        }

        [HttpGet]
        public ActionResult DeleteCountryCulture(int countryId, int cultureId)
        {
            CountryCultureViewModel vm = _adminService.GetCountryCultureViewById(countryId, cultureId);
            vm.PreviousLink = this.Url.Action("EditCountry", "Admin", new { countryId }, this.Request.Url.Scheme);

            return View(vm);
        }

        [HttpPost]
        public ActionResult DeleteCountryCulture([Bind(Include = "CountryId, CountryName, CultureId, CultureName")]CountryCultureViewModel model)
        {
            _adminService.DeleteCountryCulture(model.CountryId, model.CultureId);

            return RedirectToAction("EditCountry", new { countryId = model.CountryId });
        }

        #endregion Location

        #region Competition

        [HttpGet]
        public ActionResult Competitions()
        {
            var competitionVm = _adminService.GetCompetitions();
            return View(competitionVm);
        }

        [HttpGet]
        public ActionResult AddCompetition()
        {
            CompetitionViewModel competitionVm = new CompetitionViewModel();
            competitionVm.PreviousLink = this.Url.Action("Competitions", "Admin", this.Request.Url.Scheme);

            ViewBag.Locations = _adminService.GetLocations(LocationType.All);
            ViewBag.CompetitionTypes = _adminService.GetCompetitionTypes();

            return View(competitionVm);
        }

        [HttpPost]
        public ActionResult AddCompetition(CompetitionViewModel model)
        {
            int competitionId = _adminService.AddCompetition(model);

            return RedirectToAction("EditCompetition", new { competitionId }); //EditCompetition(competitionId);
        }

        [HttpGet]
        public ActionResult EditCompetition(int competitionId)
        {
            var competitionVm = _adminService.GetCompetitionViewById(competitionId);
            competitionVm.PreviousLink = this.Url.Action("Competitions", "Admin", this.Request.Url.Scheme);
            ViewBag.Locations = _adminService.GetLocations(LocationType.All);
            ViewBag.CompetitionTypes = _adminService.GetCompetitionTypes();

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
            CompetitionViewModel vm = _adminService.GetCompetitionViewById(competitionId);
            vm.PreviousLink = this.Url.Action("Competitions", "Admin", this.Request.Url.Scheme);

            return View(vm);
        }

        [HttpPost]
        public ActionResult DeleteCompetition([Bind(Include = "Id")]CompetitionViewModel model)
        {
            _adminService.DeleteCompetition(model.Id);

            return RedirectToAction("Competitions");
        }

        [HttpGet]
        public ActionResult AddCompetitionCulture(int competitionId)
        {
            CompetitionCultureViewModel competitionCultureVm = new CompetitionCultureViewModel();
            competitionCultureVm.CompetitionId = competitionId;
            competitionCultureVm.PreviousLink = this.Url.Action("EditCompetition", "Admin", new { competitionId }, this.Request.Url.Scheme);

            ViewBag.Cultures = _adminService.GetCultures();

            return View(competitionCultureVm);
        }

        [HttpPost]
        public ActionResult AddCompetitionCulture([Bind(Include = "CompetitionId, CompetitionName, CultureId")]CompetitionCultureViewModel model)
        {
            _adminService.AddCompetitionCulture(model);

            return RedirectToAction("EditCompetition", new { competitionId = model.CompetitionId });
        }

        [HttpGet]
        public ActionResult EditCompetitionCulture(int competitionId, int cultureId)
        {
            CompetitionCultureViewModel competitionCultureVm = _adminService.GetCompetitionCultureViewById(competitionId, cultureId);
            competitionCultureVm.PreviousLink = this.Url.Action("EditCompetition", "Admin", new { competitionId }, this.Request.Url.Scheme);

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
            CompetitionCultureViewModel vm = _adminService.GetCompetitionCultureViewById(competitionId, cultureId);
            vm.PreviousLink = this.Url.Action("EditCompetition", "Admin", new { competitionId }, this.Request.Url.Scheme);

            return View(vm);
        }

        [HttpPost]
        public ActionResult DeleteCompetitionCulture([Bind(Include = "CompetitionId, CultureId")]CompetitionCultureViewModel model)
        {
            _adminService.DeleteCompetitionCulture(model.CompetitionId, model.CultureId);

            return RedirectToAction("EditCompetition", new { competitionId = model.CompetitionId });
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
            footballPlayerVm.PreviousLink = this.Url.Action("FootballPlayers", "Admin", this.Request.Url.Scheme);

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
            footballPlayerVm.PreviousLink = this.Url.Action("FootballPlayers", "Admin", this.Request.Url.Scheme);

            return View(footballPlayerVm);
        }

        [HttpPost]
        public ActionResult EditFootballPlayer([Bind(Include = "Id, FirstName, SecondName, LastName, DateOfBirth, LocationName, PlayerImageUrl")]FootballPlayerViewModel model)
        {
            _adminService.UpdateFootballPlayer(model);

            return EditFootballPlayer(model.Id);
        }

        [HttpGet]
        public ActionResult DeleteFootballPlayer(int footballPlayerId)
        {
            FootballPlayerViewModel vm = _adminService.GetFootballPlayerViewById(footballPlayerId);
            vm.PreviousLink = this.Url.Action("FootballPlayers", "Admin", this.Request.Url.Scheme);

            return View(vm);
        }

        [HttpPost]
        public ActionResult DeleteFootballPlayer([Bind(Include = "Id")]FootballPlayerViewModel model)
        {
            _adminService.DeleteFootballPlayer(model.Id);

            return RedirectToAction("FootballPlayers");
        }

        [HttpGet]
        public ActionResult AddFootballPlayerCulture(int footballPlayerId)
        {
            FootballPlayerCultureViewModel footballPlayerCultureVm = new FootballPlayerCultureViewModel();
            footballPlayerCultureVm.FootballPlayerId = footballPlayerId;
            footballPlayerCultureVm.PreviousLink = this.Url.Action("EditFootballPlayer", "Admin", new { footballPlayerId }, this.Request.Url.Scheme);

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
            footballPlayerCultureVm.PreviousLink = this.Url.Action("EditFootballPlayer", "Admin", new { footballPlayerId }, this.Request.Url.Scheme);

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
            FootballPlayerCultureViewModel vm = _adminService.GetFootballPlayerCultureViewById(footballPlayerId, cultureId);
            vm.PreviousLink = this.Url.Action("EditFootballPlayer", "Admin", new { footballPlayerId }, this.Request.Url.Scheme);

            return View(vm);
        }

        [HttpPost]
        public ActionResult DeleteFootballPlayerCulture([Bind(Include = "FootballPlayerId, CultureId")]FootballPlayerCultureViewModel model)
        {
            _adminService.DeleteFootballPlayerCulture(model.FootballPlayerId, model.CultureId);

            return RedirectToAction("EditFootballPlayer", new { footballPlayerId = model.FootballPlayerId });
        }

        #endregion

        #region Football Team

        [HttpGet]
        public ActionResult FootballTeams()
        {
            var footballTeamVm = _adminService.GetFootballTeams();
            return View(footballTeamVm);
        }

        [HttpGet]
        public ActionResult AddFootballTeam()
        {
            FootballTeamViewModel footballTeamVm = new FootballTeamViewModel();
            footballTeamVm.PreviousLink = this.Url.Action("FootballTeams", "Admin", this.Request.Url.Scheme);

            ViewBag.Locations = _adminService.GetLocations(LocationType.All);

            return View(footballTeamVm);
        }

        [HttpPost]
        public ActionResult AddFootballTeam(FootballTeamViewModel model)
        {
            int teamId = _adminService.AddFootballTeam(model);

            return RedirectToAction("EditFootballTeam", new { footballTeamId = teamId });
        }

        [HttpGet]
        public ActionResult EditFootballTeam(int footballTeamId)
        {
            var footballTeamVm = _adminService.GetFootballTeamViewById(footballTeamId);
            footballTeamVm.PreviousLink = this.Url.Action("FootballTeams", "Admin", this.Request.Url.Scheme);

            ViewBag.Locations = _adminService.GetLocations(LocationType.All);
            ViewBag.CompetitionTypes = _adminService.GetCompetitionTypes();

            return View("EditFootballTeam", footballTeamVm);
        }

        [HttpPost]
        public ActionResult EditFootballTeam([Bind(Include = "Id, Name, EmblemImageUrl, IsActive")]FootballTeamViewModel model)
        {
            _adminService.UpdateFootballTeam(model);

            return EditFootballTeam(model.Id);
        }

        [HttpGet]
        public ActionResult DeleteFootballTeam(int footballTeamId)
        {
            FootballTeamViewModel vm = _adminService.GetFootballTeamViewById(footballTeamId);
            vm.PreviousLink = this.Url.Action("FootballTeams", "Admin", this.Request.Url.Scheme);

            return View(vm);
        }

        [HttpPost]
        public ActionResult DeleteFootballTeam([Bind(Include = "Id, Name, EmblemImageUrl, IsActive")]FootballTeamViewModel model)
        {
            _adminService.DeleteFootballTeam(model.Id);

            return RedirectToAction("FootballTeams");
        }

        [HttpGet]
        public ActionResult AddFootballTeamCulture(int footballTeamId)
        {
            FootballTeamCultureViewModel footballTeamCultureVm = new FootballTeamCultureViewModel();
            footballTeamCultureVm.FootballTeamId = footballTeamId;
            footballTeamCultureVm.PreviousLink = this.Url.Action("EditFootballTeam", "Admin", new { footballTeamId }, this.Request.Url.Scheme);

            ViewBag.Cultures = _adminService.GetCultures();

            return View(footballTeamCultureVm);
        }

        [HttpPost]
        public ActionResult AddFootballTeamCulture([Bind(Include = "FootballTeamId, FootballTeamName, CultureId")]FootballTeamCultureViewModel model)
        {
            _adminService.AddFootballTeamCulture(model);

            return RedirectToAction("EditFootballTeam", new { footballTeamId = model.FootballTeamId });
        }

        [HttpGet]
        public ActionResult EditFootballTeamCulture(int footballTeamId, int cultureId)
        {
            FootballTeamCultureViewModel footballTeamCultureVm = _adminService.GetFootballTeamCultureViewById(footballTeamId, cultureId);
            footballTeamCultureVm.PreviousLink = this.Url.Action("EditFootballTeam", "Admin", new { footballTeamId }, this.Request.Url.Scheme);

            return View(footballTeamCultureVm);
        }

        [HttpPost]
        public ActionResult EditFootballTeamCulture([Bind(Include = "FootballTeamId, FootballTeamName, CultureId")]FootballTeamCultureViewModel model)
        {
            _adminService.UpdateFootballTeamCulture(model);

            return RedirectToAction("EditFootballTeamCulture", new { footballTeamId = model.FootballTeamId, cultureId = model.CultureId });
        }

        [HttpGet]
        public ActionResult DeleteFootballTeamCulture(int footballTeamId, int cultureId)
        {
            FootballTeamCultureViewModel vm = _adminService.GetFootballTeamCultureViewById(footballTeamId, cultureId);
            vm.PreviousLink = Url.Action("EditFootballTeam", "Admin", new { footballTeamId }, this.Request.Url.Scheme);

            return View(vm);
        }

        [HttpPost]
        public ActionResult DeleteFootballTeamCulture([Bind(Include = "FootballTeamId, CultureId")]FootballTeamCultureViewModel model)
        {
            _adminService.DeleteFootballTeamCulture(model.FootballTeamId, model.CultureId);

            return RedirectToAction("EditFootballTeam", new { footballTeamId = model.FootballTeamId });
        }

        [HttpGet]
        public ActionResult AddFootballPlayerToTeam(int footballTeamId, int footballPlayerId)
        {
            FootballTeamPlayerViewModel vm = _adminService.GetFootballTeamPlayerViewByFootballPlayerId(footballPlayerId);
            vm.TeamId = footballTeamId;
            vm.PreviousLink = this.Url.Action("EditFootballTeam", "Admin", new { footballTeamId }, this.Request.Url.Scheme);
            ViewBag.PlayerStatuses = _adminService.GetPlayerStatuses();

            return View(vm);
        }

        [HttpPost]
        public ActionResult AddFootballPlayerToTeam([Bind(Include = "PlayerId, TeamId, StartDate, EndDate, PlayerStatusId")]FootballTeamPlayerViewModel model)
        {
            _adminService.AddFootballPlayerToTeam(model);

            return RedirectToAction("EditFootballTeam", new { footballTeamId = model.TeamId });
        }

        [HttpGet]
        public ActionResult DeleteFootballPlayerFromTeam(int footballTeamPlayerId)
        {
            FootballTeamPlayerViewModel vm = _adminService.GetFootballTeamPlayerViewById(footballTeamPlayerId);
            vm.PreviousLink = this.Url.Action("EditFootballTeam", "Admin", new { footballTeamId = vm.TeamId }, this.Request.Url.Scheme);

            return View(vm);
        }

        [HttpPost]
        public ActionResult DeleteFootballPlayerFromTeam([Bind(Include = "Id, TeamId")]FootballTeamPlayerViewModel model)
        {
            _adminService.DeleteFootballPlayerFromTeam(model.Id);
             
            return RedirectToAction("EditFootballTeam", new { footballTeamId = model.TeamId });
        }


        public ActionResult SearchFootballPlayer(string searchText, int? teamId)
        {
            SearchFootballPlayerViewModel filter = new SearchFootballPlayerViewModel();
            filter.TeamId = teamId.GetValueOrDefault();
            filter.SearchText = searchText;
            if (!string.IsNullOrEmpty(searchText))
            {
                filter.FoundPlayers = _adminService.GetSearchResults(filter);
            }

            return View(filter);
        }

        [HttpGet]
        public ActionResult EditFootballTeamPlayer(int footballTeamPlayerId)
        {
            FootballTeamPlayerViewModel vm = _adminService.GetFootballTeamPlayerViewModelById(footballTeamPlayerId);
            vm.PreviousLink = Url.Action("EditFootballTeam", "Admin", new { footballTeamId = vm.TeamId }, Request.Url.Scheme);
            ViewBag.PlayerStatuses = _adminService.GetPlayerStatuses();

            return View(vm);
        }

        [HttpPost]
        public ActionResult EditFootballTeamPlayer([Bind(Include = "Id, StartDate, EndDate, PlayerStatusId")]FootballTeamPlayerViewModel model)
        {
            _adminService.UpdateFootballTeamPlayer(model);

            return View(model);
        }

        #endregion
    }
}