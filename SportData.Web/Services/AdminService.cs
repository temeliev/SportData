using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using SportData.Data;
using SportData.Data.Entities;
using SportData.Data.Enums;
using SportData.Web.Helpers;
using SportData.Web.Interfaces;
using SportData.Web.Models;
using SportData.Web.Models.Admin;

namespace SportData.Web.Services
{
    public class AdminService : Service, IAdminService
    {
        public AdminService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #region Country

        public IEnumerable<CountryViewModel> GetCountries()
        {
            return UnitOfWork.Locations.Where(x => x.ParentId != null).ProjectTo<CountryViewModel>().AsEnumerable();
        }

        public List<SelectListItem> GetLocations(LocationType type)
        {
            Expression<Func<Location, bool>> locationExpression = null;
            switch (type)
            {
                case LocationType.All:
                    locationExpression = loc => true;
                    break;
                case LocationType.Continent:
                    locationExpression = loc => loc.ParentId == null;
                    break;
                case LocationType.Country:
                    locationExpression = loc => loc.ParentId != null;
                    break;
            }

            return UnitOfWork.Locations.Where(locationExpression)
                .Select(s => new SelectListItem()
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                }).ToList();
        }

        public List<SelectListItem> GetCultures()
        {
            return UnitOfWork.CultureDescription.Entities.
                Select(s => new SelectListItem()
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                }).ToList();
        }

        public CountryViewModel GetCountryViewById(int countryId)
        {
            var countryFromDb = UnitOfWork.Locations.FirstOrDefault(x => x.Id == countryId);
            if (countryFromDb == null)
            {
                throw new ArgumentNullException("Not found in database!");
            }

            var vm = AutoMapper.Mapper.Map<CountryViewModel>(countryFromDb);

            return vm;
        }

        public CountryCultureViewModel GetCountryCultureViewById(int countryId, int cultureId)
        {
            var countryFromDb = UnitOfWork.LocationCultures.FirstOrDefault(x => x.LocationId == countryId && x.CultureId == cultureId);
            if (countryFromDb == null)
            {
                throw new ArgumentNullException("Not found in database!");
            }

            var vm = AutoMapper.Mapper.Map<CountryCultureViewModel>(countryFromDb);

            return vm;
        }

        public void UpdateCountry(CountryViewModel model)
        {
            var countryFromDb = UnitOfWork.Locations.FirstOrDefault(x => x.Id == model.Id);

            if (countryFromDb == null)
            {
                throw new ArgumentNullException("Not found in database!");
            }

            countryFromDb.Name = model.Name;
            countryFromDb.LocationImageUrl = model.LocationImageUrl;
            countryFromDb.ParentId = model.ParentId;
            countryFromDb.Abbreviation = model.Abbreviation;

            UnitOfWork.SaveChanges();
        }

        public void UpdateCountryCulture(CountryCultureViewModel model)
        {
            var countryCultureFromDb =
                UnitOfWork.LocationCultures.FirstOrDefault(
                    x => x.LocationId == model.CountryId && x.CultureId == model.CultureId);

            if (countryCultureFromDb == null)
            {
                throw new ArgumentNullException("Not found in database!");
            }

            countryCultureFromDb.Name = model.CountryName;
            //countryCultureFromDb.CultureId = model.CultureId;

            UnitOfWork.SaveChanges();
        }

        public int AddCountry(CountryViewModel model)
        {
            Location location = AutoMapper.Mapper.Map<Location>(model);
            UnitOfWork.Locations.Add(location);
            UnitOfWork.SaveChanges();
            return location.Id;
        }

        public void AddCountryCulture(CountryCultureViewModel model)
        {
            LocationCulture location = AutoMapper.Mapper.Map<LocationCulture>(model);
            location.CDate = DateTime.Now;
            UnitOfWork.LocationCultures.Add(location);
            UnitOfWork.SaveChanges();
            UnitOfWork.ReloadContext();
        }

        public void DeleteCountry(int countryId)
        {
            var location = UnitOfWork.Locations.FirstOrDefault(s => s.Id == countryId);
            if (location == null)
            {
                throw new ArgumentNullException("There is no such item in database");
            }

            if (location.Cultures.Count > 0)
            {
                UnitOfWork.LocationCultures.RemoveRange(location.Cultures);
            }

            UnitOfWork.Locations.Remove(location);

            UnitOfWork.SaveChanges();
        }

        public void DeleteCountryCulture(int countryId, int cultureId)
        {
            var countryCulture = UnitOfWork.LocationCultures.FirstOrDefault(culture => culture.LocationId == countryId && culture.CultureId == cultureId);
            if (countryCulture == null)
            {
                throw new ArgumentNullException("There is no such item in database");
            }

            UnitOfWork.LocationCultures.Remove(countryCulture);
            UnitOfWork.SaveChanges();
        }

        #endregion

        #region Competition

        public IEnumerable<CompetitionViewModel> GetCompetitions()
        {
            return UnitOfWork.FootballCompetitions.Entities.AsQueryable().ProjectTo<CompetitionViewModel>().AsEnumerable();
        }

        public int AddCompetition(CompetitionViewModel model)
        {
            FootballCompetition competition = AutoMapper.Mapper.Map<FootballCompetition>(model);
            UnitOfWork.FootballCompetitions.Add(competition);
            UnitOfWork.SaveChanges();

            return competition.Id;
        }

        public void UpdateCompetition(CompetitionViewModel model)
        {
            FootballCompetition competition = UnitOfWork.FootballCompetitions.FirstOrDefault(x => x.Id == model.Id);
            if (competition == null)
            {
                throw new ArgumentNullException("There is no such item in database");
            }

            competition.Name = model.Name;
            competition.CompetitionImageUrl = model.CompetitionImageUrl;
            competition.IsActive = model.IsActive;
            competition.LocationId = model.LocationId;

            UnitOfWork.SaveChanges();
        }

        public void DeleteCompetition(int competitionId)
        {
            FootballCompetition competition = UnitOfWork.FootballCompetitions.FirstOrDefault(x => x.Id == competitionId);
            if (competition == null)
            {
                throw new ArgumentNullException("There is no such item in database");
            }

            if (competition.Cultures.Count > 0)
            {
                UnitOfWork.FootballCompetitionCultures.RemoveRange(competition.Cultures);
            }

            UnitOfWork.FootballCompetitions.Remove(competition);

            UnitOfWork.SaveChanges();
        }

        public void AddCompetitionCulture(CompetitionCultureViewModel model)
        {
            FootballCompetitionCulture competition = AutoMapper.Mapper.Map<FootballCompetitionCulture>(model);
            competition.CDate = DateTime.Now;
            UnitOfWork.FootballCompetitionCultures.Add(competition);
            UnitOfWork.SaveChanges();
            UnitOfWork.ReloadContext();
        }

        public CompetitionCultureViewModel GetCompetitionCultureViewById(int competitionId, int cultureId)
        {
            var competitionFromDb = UnitOfWork.FootballCompetitionCultures.FirstOrDefault(x => x.CompetitionId == competitionId && x.CultureId == cultureId);
            if (competitionFromDb == null)
            {
                throw new ArgumentNullException("Not found in database!");
            }

            var vm = AutoMapper.Mapper.Map<CompetitionCultureViewModel>(competitionFromDb);

            return vm;
        }

        public void UpdateCompetitionCulture(CompetitionCultureViewModel model)
        {
            var competitionCultureFromDb =
               UnitOfWork.FootballCompetitionCultures.FirstOrDefault(
                   x => x.CompetitionId == model.CompetitionId && x.CultureId == model.CultureId);

            if (competitionCultureFromDb == null)
            {
                throw new ArgumentNullException("Not found in database!");
            }

            competitionCultureFromDb.Name = model.CompetitionName;

            UnitOfWork.SaveChanges();
        }

        public void DeleteCompetitionCulture(int competitionId, int cultureId)
        {
            var competitionCultureFromDb = UnitOfWork.FootballCompetitionCultures.FirstOrDefault(culture => culture.CompetitionId == competitionId && culture.CultureId == cultureId);
            if (competitionCultureFromDb == null)
            {
                throw new ArgumentNullException("Not found in database!");
            }

            UnitOfWork.FootballCompetitionCultures.Remove(competitionCultureFromDb);
            UnitOfWork.SaveChanges();
        }

        public CompetitionViewModel GetCompetitionViewById(int competitionId)
        {
            var competitionFromDb = UnitOfWork.FootballCompetitions.FirstOrDefault(x => x.Id == competitionId);
            if (competitionFromDb == null)
            {
                throw new ArgumentNullException("Not found in database!");
            }

            var vm = AutoMapper.Mapper.Map<CompetitionViewModel>(competitionFromDb);

            return vm;
        }

        public List<SelectListItem> GetCompetitionTypes()
        {
            return UnitOfWork.CompetitionTypes.Entities.
                Select(s => new SelectListItem()
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                }).ToList();
        }

        #endregion

        #region Football Player

        public IEnumerable<FootballPlayerViewModel> GetFootballPlayers()
        {
            return UnitOfWork.FootballPlayers.Entities.AsQueryable().ProjectTo<FootballPlayerViewModel>().AsEnumerable();
        }

        public int AddFootballPlayer(FootballPlayerViewModel model)
        {
            FootballPlayer player = AutoMapper.Mapper.Map<FootballPlayer>(model);
            UnitOfWork.FootballPlayers.Add(player);
            UnitOfWork.SaveChanges();

            return player.Id;
        }

        public FootballPlayerViewModel GetFootballPlayerViewById(int footballPlayerId)
        {
            var playerFromDb = UnitOfWork.FootballPlayers.FirstOrDefault(x => x.Id == footballPlayerId);
            if (playerFromDb == null)
            {
                throw new ArgumentNullException("Not found in database!");
            }

            var vm = AutoMapper.Mapper.Map<FootballPlayerViewModel>(playerFromDb);

            return vm;
        }

        public void UpdateFootballPlayer(FootballPlayerViewModel model)
        {
            FootballPlayer player = UnitOfWork.FootballPlayers.FirstOrDefault(x => x.Id == model.Id);
            if (player == null)
            {
                throw new ArgumentNullException("There is no such item in database");
            }

            player.FirstName = model.FirstName;
            player.SecondName = model.SecondName;
            player.LastName = model.LastName;
            player.NationalityId = model.NationalityId;
            player.DateOfBirth = model.DateOfBirth;
            player.PlayerImageUrl = model.PlayerImageUrl;
            player.CDate = DateTime.Now;

            UnitOfWork.SaveChanges();
        }

        public void DeleteFootballPlayer(int footballPlayerId)
        {
            FootballPlayer player = UnitOfWork.FootballPlayers.FirstOrDefault(x => x.Id == footballPlayerId);
            if (player == null)
            {
                throw new ArgumentNullException("There is no such item in database");
            }

            if (player.Cultures.Count > 0)
            {
                UnitOfWork.FootballPlayerCultures.RemoveRange(player.Cultures);
            }

            UnitOfWork.FootballPlayers.Remove(player);

            UnitOfWork.SaveChanges();
        }

        public void AddFootballPlayerCulture(FootballPlayerCultureViewModel model)
        {
            FootballPlayerCulture player = AutoMapper.Mapper.Map<FootballPlayerCulture>(model);
            player.CDate = DateTime.Now;
            UnitOfWork.FootballPlayerCultures.Add(player);
            UnitOfWork.SaveChanges();
            UnitOfWork.ReloadContext();
        }

        public FootballPlayerCultureViewModel GetFootballPlayerCultureViewById(int footballPlayerId, int cultureId)
        {
            var playerFromDb = UnitOfWork.FootballPlayerCultures.FirstOrDefault(x => x.PlayerId == footballPlayerId && x.CultureId == cultureId);
            if (playerFromDb == null)
            {
                throw new ArgumentNullException("Not found in database!");
            }

            var vm = AutoMapper.Mapper.Map<FootballPlayerCultureViewModel>(playerFromDb);

            return vm;
        }

        public void UpdateFootballPlayerCulture(FootballPlayerCultureViewModel model)
        {
            var playerCultureFromDb =
               UnitOfWork.FootballPlayerCultures.FirstOrDefault(
                   x => x.PlayerId == model.FootballPlayerId && x.CultureId == model.CultureId);

            if (playerCultureFromDb == null)
            {
                throw new ArgumentNullException("Not found in database!");
            }

            playerCultureFromDb.FirstName = model.FirstName;
            playerCultureFromDb.SecondName = model.SecondName;
            playerCultureFromDb.LastName = model.LastName;

            UnitOfWork.SaveChanges();
        }

        public void DeleteFootballPlayerCulture(int footballPlayerId, int cultureId)
        {
            var playerCultureFromDb = UnitOfWork.FootballPlayerCultures.FirstOrDefault(culture => culture.PlayerId == footballPlayerId && culture.CultureId == cultureId);
            if (playerCultureFromDb == null)
            {
                throw new ArgumentNullException("Not found in database!");
            }

            UnitOfWork.FootballPlayerCultures.Remove(playerCultureFromDb);
            UnitOfWork.SaveChanges();
        }

        #endregion

        #region Football Team

        public IEnumerable<FootballTeamViewModel> GetFootballTeams()
        {
            return UnitOfWork.FootballTeams.Entities.AsQueryable().ProjectTo<FootballTeamViewModel>().AsEnumerable();
        }

        public int AddFootballTeam(FootballTeamViewModel model)
        {
            FootballTeam footballTeam = AutoMapper.Mapper.Map<FootballTeam>(model);
            UnitOfWork.FootballTeams.Add(footballTeam);
            UnitOfWork.SaveChanges();

            return footballTeam.Id;
        }

        public void UpdateFootballTeam(FootballTeamViewModel model)
        {
            FootballTeam footballTeam = UnitOfWork.FootballTeams.FirstOrDefault(x => x.Id == model.Id);
            if (footballTeam == null)
            {
                throw new ArgumentNullException("There is no such item in database");
            }

            footballTeam.Name = model.Name;
            footballTeam.EmblemImageUrl = model.EmblemImageUrl;
            footballTeam.IsDeleted = model.IsDeleted;
            footballTeam.LocationId = model.LocationId;
            footballTeam.CDate = DateTime.Now;

            UnitOfWork.SaveChanges();
        }

        public void DeleteFootballTeam(int footballTeamId)
        {
            FootballTeam footballTeam = UnitOfWork.FootballTeams.FirstOrDefault(x => x.Id == footballTeamId);
            if (footballTeam == null)
            {
                throw new ArgumentNullException("There is no such item in database");
            }

            if (footballTeam.Cultures.Count > 0)
            {
                UnitOfWork.FootballTeamCultures.RemoveRange(footballTeam.Cultures);
            }

            UnitOfWork.FootballTeams.Remove(footballTeam);

            UnitOfWork.SaveChanges();
        }

        public void AddFootballTeamCulture(FootballTeamCultureViewModel model)
        {
            FootballTeamCulture team = AutoMapper.Mapper.Map<FootballTeamCulture>(model);
            team.CDate = DateTime.Now;
            UnitOfWork.FootballTeamCultures.Add(team);
            UnitOfWork.SaveChanges();
            UnitOfWork.ReloadContext();
        }

        public FootballTeamCultureViewModel GetFootballTeamCultureViewById(int footballTeamId, int cultureId)
        {
            var teamFromDb = UnitOfWork.FootballTeamCultures.FirstOrDefault(x => x.TeamId == footballTeamId && x.CultureId == cultureId);
            if (teamFromDb == null)
            {
                throw new ArgumentNullException("Not found in database!");
            }

            var vm = AutoMapper.Mapper.Map<FootballTeamCultureViewModel>(teamFromDb);

            return vm;
        }

        public void UpdateFootballTeamCulture(FootballTeamCultureViewModel model)
        {
            var footballTeamCultureFromDb =
               UnitOfWork.FootballTeamCultures.FirstOrDefault(
                   x => x.TeamId == model.FootballTeamId && x.CultureId == model.CultureId);

            if (footballTeamCultureFromDb == null)
            {
                throw new ArgumentNullException("Not found in database!");
            }

            footballTeamCultureFromDb.Name = model.FootballTeamName;

            UnitOfWork.SaveChanges();
        }

        public void DeleteFootballTeamCulture(int footballTeamId, int cultureId)
        {
            var footballTeamCultureFromDb = UnitOfWork.FootballTeamCultures.FirstOrDefault(culture => culture.TeamId == footballTeamId && culture.CultureId == cultureId);
            if (footballTeamCultureFromDb == null)
            {
                throw new ArgumentNullException("Not found in database!");
            }

            UnitOfWork.FootballTeamCultures.Remove(footballTeamCultureFromDb);
            UnitOfWork.SaveChanges();
        }

        public FootballTeamViewModel GetFootballTeamViewById(int footballTeamId)
        {
            var footballTeamFromDb = UnitOfWork.FootballTeams.FirstOrDefault(x => x.Id == footballTeamId);
            if (footballTeamFromDb == null)
            {
                throw new ArgumentNullException("Not found in database!");
            }

            var vm = AutoMapper.Mapper.Map<FootballTeamViewModel>(footballTeamFromDb);

            return vm;
        }

        public void DeleteFootballPlayerFromTeam(int footballTeamPlayerId)
        {
            FootballTeamPlayer teamPlayerItem = UnitOfWork.FootballTeamsPlayers.FirstOrDefault(x => x.Id == footballTeamPlayerId);

            if (teamPlayerItem == null)
            {
                throw new ArgumentNullException("Not found in database!");
            }

            UnitOfWork.FootballTeamsPlayers.Remove(teamPlayerItem);
            UnitOfWork.SaveChanges();
        }

        public void AddFootballPlayerToTeam(FootballTeamPlayerViewModel model)
        {
            if (!UnitOfWork.FootballTeams.Any(x => x.Id == model.TeamId))
            {
                throw new ArgumentNullException("Not found in database!");
            }

            if (!UnitOfWork.FootballPlayers.Any(x => x.Id == model.PlayerId))
            {
                throw new ArgumentNullException("Not found in database!");
            }

            if (UnitOfWork.FootballTeamsPlayers.Any(
                    x => x.PlayerId == model.PlayerId &&
                    x.TeamId == model.TeamId &&
                    x.EndDate == null))
            {
                throw new ArgumentNullException("The player is already in the team!");
            }

            FootballTeamPlayer teamPlayerItem = AutoMapper.Mapper.Map<FootballTeamPlayer>(model);
            teamPlayerItem.CDate = DateTime.Now;

            UnitOfWork.FootballTeamsPlayers.Add(teamPlayerItem);
            UnitOfWork.SaveChanges();
        }

        public List<FootballTeamPlayerViewModel> GetSearchResults(SearchFootballPlayerViewModel filter)
        {
            Expression<Func<FootballPlayer, bool>> teamSearchExpression = t => true;

            if (filter.TeamId > 0)
            {
                teamSearchExpression = h => h.TeamsHistory.All(a => a.TeamId != filter.TeamId || (a.TeamId == filter.TeamId && a.EndDate != null));
            }

            var players = UnitOfWork.FootballPlayers.Where(teamSearchExpression).ToList();
            return players.Where(
                         x =>
                             x.FirstName.Contains(filter.SearchText) || 
                             (x.SecondName != null && x.SecondName.Contains(filter.SearchText)) ||
                             x.LastName.Contains(filter.SearchText))
                         .AsQueryable()
                         .ProjectTo<FootballTeamPlayerViewModel>()
                         .ToList();
        }

        public FootballTeamPlayerViewModel GetFootballTeamPlayerViewModelById(int footballTeamPlayerId)
        {
            var teamFromDb = UnitOfWork.FootballTeamsPlayers.FirstOrDefault(x => x.Id == footballTeamPlayerId);
            if (teamFromDb == null)
            {
                throw new ArgumentNullException("Not found in database!");
            }

            var vm = AutoMapper.Mapper.Map<FootballTeamPlayerViewModel>(teamFromDb);

            return vm;
        }

        public void UpdateFootballTeamPlayer(FootballTeamPlayerViewModel model)
        {
            FootballTeamPlayer footballTeamPlayer = UnitOfWork.FootballTeamsPlayers.FirstOrDefault(x => x.Id == model.Id);
            if (footballTeamPlayer == null)
            {
                throw new ArgumentNullException("There is no such item in database");
            }

            footballTeamPlayer.StartDate = model.StartDate;
            footballTeamPlayer.EndDate = model.EndDate;
            footballTeamPlayer.PlayerStatusId = model.PlayerStatusId;
            footballTeamPlayer.CDate = DateTime.Now;

            UnitOfWork.SaveChanges();
        }

        public List<SelectListItem> GetPlayerStatuses()
        {
            return UnitOfWork.PlayerStatuses.Entities.
                    Select(s => new SelectListItem()
                    {
                        Text = s.Name,
                        Value = s.Id.ToString()
                    }).ToList();
        }

        public FootballTeamPlayerViewModel GetFootballTeamPlayerViewByFootballPlayerId(int footballPlayerId)
        {
            var playerFromDb = UnitOfWork.FootballPlayers.FirstOrDefault(x => x.Id == footballPlayerId);
            if (playerFromDb == null)
            {
                throw new ArgumentNullException("Not found in database!");
            }

            var vm = AutoMapper.Mapper.Map<FootballTeamPlayerViewModel>(playerFromDb);

            return vm;
        }

        public FootballTeamPlayerViewModel GetFootballTeamPlayerViewById(int footballTeamPlayerId)
        {
            var teamPlayerFromDb = UnitOfWork.FootballTeamsPlayers.FirstOrDefault(x => x.Id == footballTeamPlayerId);
            if (teamPlayerFromDb == null)
            {
                throw new ArgumentNullException("Not found in database!");
            }

            var vm = AutoMapper.Mapper.Map<FootballTeamPlayerViewModel>(teamPlayerFromDb);

            return vm;
        }

        #endregion
    }
}