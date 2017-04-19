using System.Collections.Generic;
using System.Web.Mvc;
using SportData.Data.Enums;
using SportData.Web.Interfaces;
using SportData.Web.Models.Admin;

namespace SportData.Web.Services
{
    public interface IAdminService
    {
        IUnitOfWork UnitOfWork { get; }

        IEnumerable<CountryViewModel> GetCountries();

        List<SelectListItem> GetLocations(LocationType type);

        List<SelectListItem> GetCultures();

        CountryViewModel GetCountryViewById(int countryId);

        CountryCultureViewModel GetCountryCultureViewById(int countryId, int cultureId);

        void UpdateCountry(CountryViewModel model);

        void UpdateCountryCulture(CountryCultureViewModel model);

        int AddCountry(CountryViewModel model);

        void AddCountryCulture(CountryCultureViewModel model);

        void DeleteCountry(int countryId);

        void DeleteCountryCulture(int countryId, int cultureId);

        IEnumerable<CompetitionViewModel> GetCompetitions();

        int AddCompetition(CompetitionViewModel model);

        void UpdateCompetition(CompetitionViewModel model);

        void DeleteCompetition(int competitionId);

        void AddCompetitionCulture(CompetitionCultureViewModel model);

        CompetitionCultureViewModel GetCompetitionCultureViewById(int competitionId, int cultureId);

        void UpdateCompetitionCulture(CompetitionCultureViewModel model);

        void DeleteCompetitionCulture(int competitionId, int cultureId);

        CompetitionViewModel GetCompetitionViewById(int competitionId);

        IEnumerable<FootballPlayerViewModel> GetFootballPlayers();

        int AddFootballPlayer(FootballPlayerViewModel model);

        FootballPlayerViewModel GetFootballPlayerViewById(int footballPlayerId);

        void UpdateFootballPlayer(FootballPlayerViewModel model);

        void DeleteFootballPlayer(int footballPlayerId);

        void AddFootballPlayerCulture(FootballPlayerCultureViewModel model);

        FootballPlayerCultureViewModel GetFootballPlayerCultureViewById(int footballPlayerId, int cultureId);

        void UpdateFootballPlayerCulture(FootballPlayerCultureViewModel model);

        void DeleteFootballPlayerCulture(int footballPlayerId, int cultureId);

        IEnumerable<FootballTeamViewModel> GetFootballTeams();

        int AddFootballTeam(FootballTeamViewModel model);

        FootballTeamViewModel GetFootballTeamViewById(int footballTeamId);

        void UpdateFootballTeam(FootballTeamViewModel model);

        void DeleteFootballTeam(int footballTeamId);

        void AddFootballTeamCulture(FootballTeamCultureViewModel model);

        FootballTeamCultureViewModel GetFootballTeamCultureViewById(int footballTeamId, int cultureId);

        void UpdateFootballTeamCulture(FootballTeamCultureViewModel model);

        void DeleteFootballTeamCulture(int footballTeamId, int cultureId);

        List<FootballTeamPlayerViewModel> GetSearchResults(SearchFootballPlayerViewModel filter);

        void AddFootballPlayerToTeam(FootballTeamPlayerViewModel model);

        void DeleteFootballPlayerFromTeam(int footballTeamPlayerId);

        FootballTeamPlayerViewModel GetFootballTeamPlayerViewModelById(int footballTeamPlayerId);

        void UpdateFootballTeamPlayer(FootballTeamPlayerViewModel model);

        List<SelectListItem> GetPlayerStatuses();

        List<SelectListItem> GetCompetitionTypes();

        FootballTeamPlayerViewModel GetFootballTeamPlayerViewByFootballPlayerId(int footballPlayerId);

        FootballTeamPlayerViewModel GetFootballTeamPlayerViewById(int footballTeamPlayerId);
    }
}
