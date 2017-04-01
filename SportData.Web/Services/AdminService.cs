using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using SportData.Data.Entities;
using SportData.Data.Enums;
using SportData.Web.Interfaces;
using SportData.Web.Models.Admin;

namespace SportData.Web.Services
{
    public class AdminService : Service
    {
        public AdminService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<CountryViewModel> GetCountries()
        {
            return UnitOfWork.LocationCultures.Where(x => x.Location.ParentId != null).ProjectTo<CountryViewModel>().AsEnumerable();
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

        public List<SelectListItem> GetCultures()
        {
            return UnitOfWork.CultureDescription.Entities.
                Select(s => new SelectListItem()
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                }).ToList();
        }
    }
}