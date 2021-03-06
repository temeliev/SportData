﻿using System;
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
        private static int _cultureId;

        public HomeService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _cultureId = (int)CultureHelper.GetCurrentCultureType();
        }

        public List<GroupedMatchesViewModel> GetMatchesByDate(DateTime date, MatchStatus status)
        {
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
                        Matches = s.Competition.Matches.Where(w => DbFunctions.TruncateTime(w.MatchDate) == date.Date).Select(s1 => new FootballMatchViewModel
                        {
                            MatchId = s1.Id,
                            MatchStatusName = s1.Status.Cultures.FirstOrDefault(c => c.CultureId == cultureId).Name,
                            MatchStatusId = s1.Status.Id,
                            HomeTeamName = s1.HomeTeam.Cultures.FirstOrDefault(c => c.CultureId == cultureId).Name,
                            AwayTeamName = s1.AwayTeam.Cultures.FirstOrDefault(c => c.CultureId == cultureId).Name,
                            MatchResult =
                                 (s1.StatusId == (int)Data.Enums.MatchStatus.NotStarted
                                     ? " - "
                                     : s1.Events.Count(ev => ev.TeamId == s1.HomeTeamId && ev.EventTypeId == (int)Data.Enums.EventType.Goal)
                                       + " - " +
                                       s1.Events.Count(ev => ev.TeamId == s1.AwayTeamId && ev.EventTypeId == (int)Data.Enums.EventType.Goal)),
                            MatchDate = s1.MatchDate
                        }).ToList()
                    }).ToList();

            if (status == MatchStatus.Finished)
            {
                return result.Where(g => g.Matches.Any(a => a.MatchStatusId == (int)MatchStatus.Finished)).ToList();
            }

            if (status == MatchStatus.NotStarted)
            {
                return result.Where(g => g.Matches.Any(a => a.MatchStatusId == (int)MatchStatus.NotStarted)).ToList();
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

        public Dictionary<string, List<FootballLeagueRankingViewModel>> GetRanking(int competitionId, RankingType rankingType, int seasonId)
        {
            CultureType cultureType = CultureHelper.GetCurrentCultureType();
            var result = (from team in UnitOfWork.FootballTeams
                          where
                          team.HomeTeamMatches.Any(
                              home => home.CompetitionId == competitionId && home.SeasonId == seasonId) ||
                          team.AwayTeamMatches.Any(
                              away => away.CompetitionId == competitionId && away.SeasonId == seasonId)
                          group team by new { team.Id, team.Cultures.FirstOrDefault(x => x.CultureId == (int)cultureType).Name, team.EmblemImageUrl } into gr
                          select new FootballLeagueRankingViewModel
                          {
                              Round = Resources.Resources.LeagueRankingTeamCaption,
                              TeamId = gr.Key.Id,
                              TeamName = gr.Key.Name,
                              TeamImageUrl = gr.Key.EmblemImageUrl,
                              HomeWins = gr.Sum(c =>
                                              c.HomeTeamMatches.Count(
                                                  home => home.Events.Count(ev => ev.EventTypeId == (int)Data.Enums.EventType.Goal && ev.TeamId == gr.Key.Id) >
                                                          home.Events.Count(ev => ev.EventTypeId == (int)Data.Enums.EventType.Goal && ev.TeamId != gr.Key.Id))),
                              AwayWins = gr.Sum(c =>
                                              c.AwayTeamMatches.Count(
                                                  away => away.Events.Count(ev => ev.EventTypeId == (int)Data.Enums.EventType.Goal && ev.TeamId == gr.Key.Id) >
                                                          away.Events.Count(ev => ev.EventTypeId == (int)Data.Enums.EventType.Goal && ev.TeamId != gr.Key.Id))),
                              HomeDraws = gr.Sum(c =>
                                              c.HomeTeamMatches.Count(
                                                  home => home.Events.Count(ev => ev.EventTypeId == (int)Data.Enums.EventType.Goal && ev.TeamId == gr.Key.Id) ==
                                                          home.Events.Count(ev => ev.EventTypeId == (int)Data.Enums.EventType.Goal && ev.TeamId != gr.Key.Id))),
                              AwayDraws = gr.Sum(c =>
                                              c.AwayTeamMatches.Count(
                                                  away => away.Events.Count(ev => ev.EventTypeId == (int)Data.Enums.EventType.Goal && ev.TeamId == gr.Key.Id) ==
                                                          away.Events.Count(ev => ev.EventTypeId == 1 && ev.TeamId != gr.Key.Id))),
                              HomeLosses = gr.Sum(c =>
                                              c.HomeTeamMatches.Count(
                                                  home => home.Events.Count(ev => ev.EventTypeId == (int)Data.Enums.EventType.Goal && ev.TeamId == gr.Key.Id) <
                                                          home.Events.Count(ev => ev.EventTypeId == (int)Data.Enums.EventType.Goal && ev.TeamId != gr.Key.Id))),
                              AwayLosses = gr.Sum(c =>
                                              c.AwayTeamMatches.Count(
                                                  away => away.Events.Count(ev => ev.EventTypeId == (int)Data.Enums.EventType.Goal && ev.TeamId == gr.Key.Id) <
                                                          away.Events.Count(ev => ev.EventTypeId == (int)Data.Enums.EventType.Goal && ev.TeamId != gr.Key.Id))),

                              PlayedMatchesAtHome = gr.Sum(c => c.HomeTeamMatches.Count()),

                              PlayedMatchesAway = gr.Sum(c => c.AwayTeamMatches.Count()),

                              HomeGoalScored = gr.Sum(s => s.HomeTeamMatches.Sum(
                                                  home => home.Events.Count(ev => ev.EventTypeId == (int)Data.Enums.EventType.Goal && ev.TeamId == gr.Key.Id))),

                              AwayGoalScored = gr.Sum(s => s.AwayTeamMatches.Sum(
                                                  home => home.Events.Count(ev => ev.EventTypeId == (int)Data.Enums.EventType.Goal && ev.TeamId == gr.Key.Id))),

                              HomeGoalReceived = gr.Sum(s => s.HomeTeamMatches.Sum(
                                                  home => home.Events.Count(ev => ev.EventTypeId == (int)Data.Enums.EventType.Goal && ev.TeamId != gr.Key.Id))),

                              AwayGoalReceived = gr.Sum(s => s.AwayTeamMatches.Sum(
                                                  home => home.Events.Count(ev => ev.EventTypeId == (int)Data.Enums.EventType.Goal && ev.TeamId != gr.Key.Id))),

                          }).ToList();

            IOrderedEnumerable<FootballLeagueRankingViewModel> orderedTeams = null;
            switch (rankingType)
            {
                case RankingType.All:
                    orderedTeams = result.OrderByDescending(order => order.Points);
                    break;
                case RankingType.Home:
                    orderedTeams = result.OrderByDescending(order => order.HomePoints);
                    break;
                case RankingType.Away:
                    orderedTeams = result.OrderByDescending(order => order.AwayPoints);
                    break;
            }

            int count = 1;
            foreach (var item in orderedTeams)
            {
                item.Position = count;
                count++;
            }

            return orderedTeams.GroupBy(gr => gr.Round, gr => gr).ToDictionary(x => x.Key, x => x.ToList());
        }

        public FootballTeamsCompareInfoViewModel GetFootballCompareInfo(long matchId)
        {
            int cultureId = (int)CultureHelper.GetCurrentCultureType();

            var result = (from match in UnitOfWork.Matches
                          where match.Id == matchId
                          select
                          new FootballTeamsCompareInfoViewModel
                          {
                              MatchId = match.Id,
                              MatchDate = match.MatchDate,
                              MatchStatus =
                                      match.Status.Cultures.FirstOrDefault(
                                          c => c.CultureId == cultureId).Name,
                              HostTeamId = match.HomeTeamId,
                              HostTeamName =
                                      match.HomeTeam.Cultures.FirstOrDefault(
                                          c => c.CultureId == cultureId).Name,
                              HostTeamEmblemUrl = match.HomeTeam.EmblemImageUrl,
                              VisitorTeamId = match.AwayTeamId,
                              VisitorTeamName =
                                      match.AwayTeam.Cultures.FirstOrDefault(
                                          c => c.CultureId == cultureId).Name,
                              VisitorTeamEmblemUrl = match.AwayTeam.EmblemImageUrl,
                              Score = match.Events.Count(ev => ev.TeamId == match.HomeTeamId && ev.EventTypeId == (int)Data.Enums.EventType.Goal)
                                      + " - " +
                                      match.Events.Count(ev => ev.TeamId == match.AwayTeamId && ev.EventTypeId == (int)Data.Enums.EventType.Goal)
                          }).FirstOrDefault();

            return result;
        }

        //private Expression<System.Func<Match, FootballMatchViewModel>> selectMatchViewModel = (match) =>
        //        new FootballMatchViewModel()
        //        {
        //            MatchDate = match.MatchDate,
        //            MatchId = match.Id,
        //            MatchStatusName = match.Status.Cultures.FirstOrDefault(x => x.CultureId == 1).Name,
        //            CompetitionName = match.Competition.Cultures.FirstOrDefault(x => x.CultureId == 1).Name,
        //            CompetitionLocationName = match.Competition.Location.Cultures.FirstOrDefault(x => x.CultureId == 1).Name,
        //            HomeTeamName = match.HomeTeam.Cultures.FirstOrDefault(x => x.CultureId == 1).Name,
        //            AwayTeamName = match.AwayTeam.Cultures.FirstOrDefault(x => x.CultureId == 1).Name,
        //            CompetitionEmblemUrl = match.Competition.CompetitionImageUrl,
        //            MatchResult = ((match.StatusId == (int)Data.Enums.MatchStatus.NotStarted || match.StatusId == (int)Data.Enums.MatchStatus.Suspended)
        //                               ? " - "
        //                               : match.Events.Count(ev => ev.TeamId == match.HomeTeamId && ev.EventTypeId == (int)Data.Enums.EventType.Goal)
        //                                 + " - " +
        //                                 match.Events.Count(ev => ev.TeamId == match.AwayTeamId && ev.EventTypeId == (int)Data.Enums.EventType.Goal))
        //};

        private Expression<System.Func<Match, FootballMatchViewModel>> SelectMatchViewModel(int culture)
        {
            Expression<System.Func<Match, FootballMatchViewModel>> expression = (match) =>
                new FootballMatchViewModel()
                {
                    MatchDate = match.MatchDate,
                    MatchId = match.Id,
                    MatchStatusName = match.Status.Cultures.FirstOrDefault(x => x.CultureId == culture).Name,
                    CompetitionName = match.Competition.Cultures.FirstOrDefault(x => x.CultureId == culture).Name,
                    CompetitionLocationName = match.Competition.Location.Cultures.FirstOrDefault(x => x.CultureId == culture).Name,
                    HomeTeamName = match.HomeTeam.Cultures.FirstOrDefault(x => x.CultureId == culture).Name,
                    AwayTeamName = match.AwayTeam.Cultures.FirstOrDefault(x => x.CultureId == culture).Name,
                    CompetitionEmblemUrl = match.Competition.CompetitionImageUrl,
                    MatchResult = ((match.StatusId == (int)Data.Enums.MatchStatus.NotStarted || match.StatusId == (int)Data.Enums.MatchStatus.Suspended)
                                       ? " - "
                                       : match.Events.Count(ev => ev.TeamId == match.HomeTeamId && ev.EventTypeId == (int)Data.Enums.EventType.Goal)
                                         + " - " +
                                         match.Events.Count(ev => ev.TeamId == match.AwayTeamId && ev.EventTypeId == (int)Data.Enums.EventType.Goal))
                };

            return expression;
        }


        public FootballTeamsCompareInfoDetailsViewModel GetLastFootballMatches(int hostTeamId, int visitorTeamId, MatchCompareType type, int topRows)
        {
            FootballTeamsCompareInfoDetailsViewModel vm = new FootballTeamsCompareInfoDetailsViewModel();
            int cultureId = (int)CultureHelper.GetCurrentCultureType();
            switch (type)
            {
                case MatchCompareType.Overall:
                    vm.HostMatches = (from match in UnitOfWork.Matches
                                      where
                                      (match.HomeTeamId == hostTeamId || match.AwayTeamId == hostTeamId)
                                      && match.StatusId == (int)MatchStatus.Finished
                                      select match).Select(SelectMatchViewModel(cultureId))
                                      .OrderByDescending(o => o.MatchDate)
                                      .Take(topRows)
                                      .ToList();

                    vm.VisitorMatches = (from match in UnitOfWork.Matches
                                         where
                                         (match.HomeTeamId == visitorTeamId || match.AwayTeamId == visitorTeamId)
                                         && match.StatusId == (int)MatchStatus.Finished
                                         select match).Select(SelectMatchViewModel(cultureId))
                                      .OrderByDescending(o => o.MatchDate)
                                      .Take(topRows)
                                      .ToList();

                    vm.BetweenMatches = (from match in UnitOfWork.Matches
                                         where
                                         ((match.HomeTeamId == hostTeamId && match.AwayTeamId == visitorTeamId) ||
                                         ((match.HomeTeamId == visitorTeamId && match.AwayTeamId == hostTeamId)))
                                         && match.StatusId == (int)MatchStatus.Finished
                                         select match).Select(SelectMatchViewModel(cultureId))
                                         .OrderByDescending(o => o.MatchDate)
                                         .Take(topRows)
                                         .ToList();
                    break;

                case MatchCompareType.Host:
                    vm.HostMatches = (from match in UnitOfWork.Matches
                                      where
                                      match.HomeTeamId == hostTeamId
                                      && match.StatusId == (int)MatchStatus.Finished
                                      select match).Select(SelectMatchViewModel(cultureId))
                                       .OrderByDescending(o => o.MatchDate)
                                       .Take(topRows)
                                       .ToList();

                    vm.BetweenMatches = (from match in UnitOfWork.Matches
                                         where
                                         (match.HomeTeamId == hostTeamId && match.AwayTeamId == visitorTeamId) &&
                                         match.StatusId == (int)MatchStatus.Finished
                                         select match).Select(SelectMatchViewModel(cultureId))
                                      .OrderByDescending(o => o.MatchDate)
                                      .Take(topRows)
                                      .ToList();
                    break;

                case MatchCompareType.Visitor:
                    vm.VisitorMatches = (from match in UnitOfWork.Matches
                                         where
                                         match.AwayTeamId == visitorTeamId
                                         && match.StatusId == (int)MatchStatus.Finished
                                         select match).Select(SelectMatchViewModel(cultureId))
                                       .OrderByDescending(o => o.MatchDate)
                                       .Take(topRows)
                                       .ToList();

                    vm.BetweenMatches = (from match in UnitOfWork.Matches
                                         where
                                         (match.HomeTeamId == hostTeamId && match.AwayTeamId == visitorTeamId) &&
                                         match.StatusId == (int)MatchStatus.Finished
                                         select match).Select(SelectMatchViewModel(cultureId))
                                      .OrderByDescending(o => o.MatchDate)
                                      .Take(topRows)
                                      .ToList();
                    break;
            }

            return vm;
        }
    }
}