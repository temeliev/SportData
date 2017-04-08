using AutoMapper;
using SportData.Data.Entities;
using SportData.Web.Models.Admin;

namespace SportData.Web
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<LocationCulture, CountryCultureViewModel>()
                    .ForMember(dst => dst.CultureName, opt => opt.MapFrom(src => src.Culture.ShowText))
                    .ForMember(dst => dst.CountryId, opt => opt.MapFrom(src => src.LocationId))
                    .ForMember(dst => dst.CountryName, opt => opt.MapFrom(src => src.Name));

                cfg.CreateMap<CountryCultureViewModel, LocationCulture>()
                    .ForMember(dst => dst.CultureId, opt => opt.MapFrom(src => src.CultureId))
                    .ForMember(dst => dst.LocationId, opt => opt.MapFrom(src => src.CountryId))
                    //.ForMember(dst => dst.Culture.ShowText, opt => opt.MapFrom(src => src))
                    .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.CountryName));

                cfg.CreateMap<Location, CountryViewModel>()
                    .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dst => dst.LocationName, opt => opt.MapFrom(src => src.Parent.Name))
                    .ForMember(dst => dst.Abbreviation, opt => opt.MapFrom(src => src.Abbreviation))
                    .ForMember(dst => dst.ParentId, opt => opt.MapFrom(src => src.ParentId));

                cfg.CreateMap<CountryViewModel, Location>();
            });
        }
    }
}