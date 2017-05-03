using System.Linq;
using AutoMapper;
using SportData.Data.Entities;
using SportData.Web.Models;
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
                    .ForMember(dst => dst.LocationName, opt => opt.MapFrom(src => src.Location.Name))
                    .ForMember(dst => dst.CompetitionTypeId, opt => opt.MapFrom(src => src.CompetitionTypeId))
                    .ForMember(dst => dst.CompetitionTypeName, opt => opt.MapFrom(src => src.CompetitionType.Name));

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

                cfg.CreateMap<FootballTeamViewModel, FootballTeam>();
                //.ForMember(dst => dst.DateOfBirth, opt => opt.MapFrom(src => Convert.ToDateTime(src.DateOfBirthTest)));

                cfg.CreateMap<FootballTeam, FootballTeamViewModel>()
                    .ForMember(dst => dst.LocationName, opt => opt.MapFrom(src => src.Location.Name));
                //.ForMember(dst=>dst.Players, opt => opt.MapFrom(src => src.Players));

                cfg.CreateMap<FootballTeamCultureViewModel, FootballTeamCulture>()
                    .ForMember(dst => dst.TeamId, opt => opt.MapFrom(src => src.FootballTeamId))
                    .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.FootballTeamName));

                cfg.CreateMap<FootballTeamCulture, FootballTeamCultureViewModel>()
                    .ForMember(dst => dst.FootballTeamName, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dst => dst.FootballTeamId, opt => opt.MapFrom(src => src.TeamId))
                    .ForMember(dst => dst.CultureName, opt => opt.MapFrom(src => src.Culture.ShowText));

                cfg.CreateMap<FootballTeamPlayer, FootballPlayerViewModel>()
                    .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.PlayerId))
                    .ForMember(dst => dst.FirstName, opt => opt.MapFrom(src => src.Player.FirstName))
                    .ForMember(dst => dst.SecondName, opt => opt.MapFrom(src => src.Player.SecondName))
                    .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.Player.LastName))
                    .ForMember(dst => dst.LocationName, opt => opt.MapFrom(src => src.Player.Nationality.Name))
                    .ForMember(dst => dst.NationalityImageUrl, opt => opt.MapFrom(src => src.Player.Nationality.LocationImageUrl));

                cfg.CreateMap<FootballTeamPlayerViewModel, FootballTeamPlayer>();

                cfg.CreateMap<FootballTeamPlayer, FootballTeamPlayerViewModel>()
                    .ForMember(dst => dst.PlayerFullName, opt => opt.MapFrom(src => src.Player.FirstName + " " + src.Player.SecondName + " " + src.Player.LastName))
                    .ForMember(dst => dst.LocationName, opt => opt.MapFrom(src => src.Player.Nationality.Name))
                    .ForMember(dst => dst.NationalityImageUrl, opt => opt.MapFrom(src => src.Player.Nationality.LocationImageUrl))
                    .ForMember(dst => dst.PlayerStatusId, opt => opt.MapFrom(src => src.PlayerStatusId))
                    .ForMember(dst => dst.PlayerStatusName, opt => opt.MapFrom(src => src.PlayerStatus.Name));

                cfg.CreateMap<FootballPlayer, FootballTeamPlayerViewModel>()
                    .ForMember(dst => dst.PlayerFullName, opt => opt.MapFrom(src => src.FirstName + " " + src.SecondName + " " + src.LastName))
                    .ForMember(dst => dst.LocationName, opt => opt.MapFrom(src => src.Nationality.Name))
                    .ForMember(dst => dst.NationalityImageUrl, opt => opt.MapFrom(src => src.Nationality.LocationImageUrl))
                    .ForMember(dst => dst.PlayerId, opt => opt.MapFrom(src => src.Id));


                cfg.CreateMap<Location, LocationViewModel>();

                cfg.CreateMap<FootballCompetition, CompetitionCultureViewModel>()
                    .ForMember(dst => dst.CompetitionName, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dst => dst.CompetitionId, opt => opt.MapFrom(src => src.Id));
                //.ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.LocationId))
                //.ForMember(x=>x.Competitions, opt => opt.MapFrom(src => src.Location.Competitions));

                //cfg.CreateMap<Match, FootballMatchViewModel>()
                //    .ForMember(dst => dst.MatchId, opt => opt.MapFrom(src => src.Id))
                //    .ForMember(dst => dst.MatchStatusName, opt => opt.MapFrom(src => src.Status.Cultures.Fir))
            });
        }
    }
}