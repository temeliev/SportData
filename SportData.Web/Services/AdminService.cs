using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using SportData.Data;
using SportData.Data.Entities;
using SportData.Data.Enums;
using SportData.Web.Interfaces;
using SportData.Web.Models;
using SportData.Web.Models.Admin;

namespace SportData.Web.Services
{
    public class AdminService : Service
    {
        public AdminService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #region Country

        public IEnumerable<CountryViewModel> GetCountries()
        {
            return UnitOfWork.Locations.Where(x => x.ParentId != null).ProjectTo<CountryViewModel>().AsEnumerable();
        }

        public List<SelectListItem> GetMainLocations()
        {
            return UnitOfWork.LocationCultures.Where(x => x.Location.ParentId == null && x.CultureId == (int)CultureType.Bg)
                .Select(s => new SelectListItem()
                {
                    Text = s.Name,
                    Value = s.LocationId.ToString()
                }).ToList();
        }

        public List<SelectListItem> GetAllLocations()
        {
            return UnitOfWork.LocationCultures.Where(x => x.CultureId == (int)CultureType.Bg)
                .Select(s => new SelectListItem()
                {
                    Text = s.Name,
                    Value = s.LocationId.ToString()
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

        #endregion
    }
}