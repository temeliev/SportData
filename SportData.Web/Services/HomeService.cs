using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime.Misc;
using AutoMapper.QueryableExtensions;
using SportData.Data;
using SportData.Data.Entities;
using SportData.Data.Enums;
using SportData.Web.Helpers;
using SportData.Web.Interfaces;
using SportData.Web.Models;
using SportData.Web.Models.Admin;
using MatchStatus = SportData.Data.Enums.MatchStatus;

namespace SportData.Web.Services
{
    public class HomeService : Service, IHomeService
    {
        public HomeService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public List<GroupedMatchesViewModel> GetMatchesByDate(DateTime date, MatchStatus status)
        {
            ////TODO
            //var result1 =
            //    UnitOfWork.Matches.Where(x => DbFunctions.TruncateTime(x.MatchDate) == date.Date)
            //        .GroupBy(x => new { x.CompetitionId, x.Competition.Name })
            //        .Select(s => new GroupedMatchesViewModel()
            //        {
            //            FootballCompetitionName = s.Key.Name,
            //            FootballCompetitionId = s.Key.CompetitionId,
            //            Matches = s.Select(m => new FootballMatchViewModel
            //            {
            //                MatchId = m.Id,
            //                MatchStatusName = m.Status.Cultures.FirstOrDefault(c => c.CultureId == 1)?.Name
            //            }).ToList()
            //        });
            int cultureId = (int)CultureHelper.GetCurrentCultureType();
            var result =
                UnitOfWork.FootballCompetitionCultures.Where(
                        x =>
                            x.Competition.Matches.Any(m => DbFunctions.TruncateTime(m.MatchDate) == date.Date) &&
                            x.CultureId == cultureId)

                    .Select(s => new GroupedMatchesViewModel()
                    {
                        FootballCompetitionName = s.Name,
                        FootballCompetitionId = s.CompetitionId,
                        CompetitionLocationName = s.Competition.Location.Cultures.FirstOrDefault(c => c.CultureId == cultureId).Name,
                        CompetitionLocationFlagUrl = s.Competition.Location.LocationImageUrl,
                        Matches = s.Competition.Matches.Select(s1 => new FootballMatchViewModel
                        {
                            MatchId = s1.Id,
                            MatchStatusName = s1.Status.Cultures.FirstOrDefault(c => c.CultureId == cultureId).Name,
                            MatchStatusId = s1.Status.Id,
                            HomeTeamName = s1.HomeTeam.Cultures.FirstOrDefault(c => c.CultureId == cultureId).Name,
                            AwayTeamName = s1.AwayTeam.Cultures.FirstOrDefault(c => c.CultureId == cultureId).Name,
                            MatchResult =
                                (s1.StatusId == (int)Data.Enums.MatchStatus.NotStarted
                                    ? " - "
                                    : s1.Events.Count(ev => ev.TeamId == s1.HomeTeamId && ev.EventTypeId == 1) + " - " +
                                      s1.Events.Count(ev => ev.TeamId == s1.AwayTeamId && ev.EventTypeId == 1)),
                            MatchDate = s1.MatchDate
                        }).ToList()
                    }).ToList();

            if (status == MatchStatus.Finished)
            {
                return result.Where(g => g.Matches.All(a => a.MatchStatusId == (int)MatchStatus.Finished)).ToList();
            }

            if (status == MatchStatus.NotStarted)
            {
                return result.Where(g => g.Matches.All(a => a.MatchStatusId == (int)MatchStatus.NotStarted)).ToList();
            }

            return result;
        }

        public List<LocationViewModel> GetLocationsByType(LocationType type)
        {
            Expression<System.Func<LocationCulture, bool>> locationExpression = null;
            switch (type)
            {
                case LocationType.All:
                    locationExpression = loc => true;
                    break;
                case LocationType.Continent:
                    locationExpression = loc => loc.Location.ParentId == null;
                    break;
                case LocationType.Country:
                    locationExpression = loc => loc.Location.ParentId != null;
                    break;
            }

            CultureType cultureType = CultureHelper.GetCurrentCultureType();
            Expression<System.Func<LocationCulture, bool>> cultureExpression = c => c.CultureId == (int)cultureType;

            var locations = UnitOfWork.LocationCultures
                .Where(locationExpression.And(cultureExpression))
                .OrderBy(x => x.Name)
                .Select(s => new LocationViewModel()
                {
                    Id = s.LocationId,
                    Name = s.Name,
                    Competitions =
                        s.Location.Competitions.SelectMany(x => x.Cultures)
                            .Where(x => x.CultureId == (int)cultureType)
                            .Select(s1 => new CompetitionCultureViewModel()
                            {
                                CompetitionId = s1.CompetitionId,
                                CompetitionName = s1.Name
                            })
                            .ToList()

                })
                .ToList();

            return locations;
        }

        public List<SelectListItem> GetDateList()
        {
            DateTime startDate = DateTime.Now.AddDays(-6);
            DateTime endDate = DateTime.Now.AddDays(6);
            List<string> dates = new List<string>();
            for (DateTime i = startDate; i < endDate; i = i.AddDays(1))
            {
                string day = (i.Day < 10 ? "0" + i.Day : i.Day.ToString());
                string month = (i.Month < 10 ? "0" + i.Month : i.Month.ToString());
                dates.Add(day + "/" + month);
            }

            return dates.Select(s => new SelectListItem()
            {
                Value = s,
                Text = s
            }).ToList();
        }

        public DateTime GetDateFromString(string dateStr)
        {
            int day = int.Parse(dateStr.Substring(0, 2));
            int month = int.Parse(dateStr.Substring(3, 2));

            return new DateTime(DateTime.Now.Year, month, day);
        }
    }
}