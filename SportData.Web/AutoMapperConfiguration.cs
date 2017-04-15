using System;
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
                    .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.CountryName));

                cfg.CreateMap<Location, CountryViewModel>()
                    .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dst => dst.LocationName, opt => opt.MapFrom(src => src.Parent.Name))
                    .ForMember(dst => dst.Abbreviation, opt => opt.MapFrom(src => src.Abbreviation))
                    .ForMember(dst => dst.ParentId, opt => opt.MapFrom(src => src.ParentId));

                cfg.CreateMap<CountryViewModel, Location>();

                cfg.CreateMap<CompetitionViewModel, FootballCompetition>();
                cfg.CreateMap<FootballCompetition, CompetitionViewModel>()
                    .ForMember(dst => dst.LocationName, opt => opt.MapFrom(src => src.Location.Name));

                cfg.CreateMap<CompetitionCultureViewModel, FootballCompetitionCulture>()
                    .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.CompetitionName));

                cfg.CreateMap<FootballCompetitionCulture, CompetitionCultureViewModel>()
                    .ForMember(dst => dst.CompetitionName, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dst => dst.CultureName, opt => opt.MapFrom(src => src.Culture.ShowText));


                cfg.CreateMap<FootballPlayerViewModel, FootballPlayer>();
                    //.ForMember(dst => dst.DateOfBirth, opt => opt.MapFrom(src => Convert.ToDateTime(src.DateOfBirthTest)));

                cfg.CreateMap<FootballPlayer, FootballPlayerViewModel>()
                    .ForMember(dst => dst.NationalityImageUrl, opt => opt.MapFrom(src => src.Nationality.LocationImageUrl))
                    .ForMember(dst => dst.LocationName, opt => opt.MapFrom(src => src.Nationality.Name));

                cfg.CreateMap<FootballPlayerCultureViewModel, FootballPlayerCulture>()
                    .ForMember(dst => dst.PlayerId, opt => opt.MapFrom(src => src.FootballPlayerId));

                cfg.CreateMap<FootballPlayerCulture, FootballPlayerCultureViewModel>()
                    .ForMember(dst => dst.FootballPlayerId, opt => opt.MapFrom(src => src.PlayerId))
                    .ForMember(dst => dst.CultureName, opt => opt.MapFrom(src => src.Culture.ShowText));
            });
        }
    }
}