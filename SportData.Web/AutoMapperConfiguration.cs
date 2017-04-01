using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using SportData.Data.Entities;
using SportData.Data.Enums;
using SportData.Web.Models.Admin;

namespace SportData.Web
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<LocationCulture, CountryViewModel>()
                .ForMember(dst => dst.CountryName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.LocationName, opt => opt.MapFrom(src => src.Location.Parent.Cultures.Where(pc => pc.CultureId == (int)CultureType.Bg).Select(s => s.Name).FirstOrDefault()))
                .ForMember(dst => dst.Abbreviation, opt => opt.MapFrom(src => src.Location.Abbreviation))
                .ForMember(dst => dst.ParentId, opt => opt.MapFrom(src => src.Location.ParentId));
                cfg.CreateMap<CountryViewModel, Location>();
            });
        }
    }
}