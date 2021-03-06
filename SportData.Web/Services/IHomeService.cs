﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SportData.Data.Enums;
using SportData.Web.Interfaces;
using SportData.Web.Models;

namespace SportData.Web.Services
{
    public interface IHomeService
    {
        List<GroupedMatchesViewModel> GetMatchesByDate(DateTime date, MatchStatus status);

        List<LocationViewModel> GetLocationsByType(LocationType type);

        IUnitOfWork UnitOfWork { get; }

        List<SelectListItem> GetDateList();

        DateTime GetDateFromString(string date);

        Dictionary<string, List<FootballLeagueRankingViewModel>> GetRanking(int competitionId, RankingType rankingType, int seasonId);

        FootballTeamsCompareInfoViewModel GetFootballCompareInfo(long matchId);

        FootballTeamsCompareInfoDetailsViewModel GetLastFootballMatches(int hostTeamId, int visitorTeamId, MatchCompareType type, int topRows);
    }
}
