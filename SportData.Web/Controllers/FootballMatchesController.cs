using System;
using System.Web.Mvc;
using SportData.Data.Enums;
using SportData.Web.Models;
using SportData.Web.Services;

namespace SportData.Web.Controllers
{
    public class FootballMatchesController : BaseController
    {
        private readonly IHomeService _homeService;

        public FootballMatchesController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        [HttpGet]
        public PartialViewResult FootballMatches(string date, MatchStatus status)
        {
            FootballMatchesViewModel vm = new FootballMatchesViewModel();
            DateTime selectedDate = _homeService.GetDateFromString(date);
            vm.Matches = _homeService.GetMatchesByDate(selectedDate, status);
            vm.MatchStatus = status;

            return PartialView("_FootballMatchesTable", vm);
        }

        public PartialViewResult FootballLeagueRanking(int competitionId, RankingType type)
        {
            FootballLeagueRankingInfoViewModel vm = new FootballLeagueRankingInfoViewModel();
            vm.CompetitionId = competitionId;

            return PartialView("_FootballLeagueRankingInfo", vm);
        }

        public PartialViewResult FootballLeagueRankingDetail(int competitionId, RankingType type)
        {
            FootballLeagueRankingInfoViewModel vm = new FootballLeagueRankingInfoViewModel();
            vm.CompetitionId = competitionId;
            vm.RankingType = type;
            vm.Ranking = this._homeService.GetRanking(competitionId, type, 1);

            return PartialView("_FootballLeagueRankingTable", vm);
        }

        public ActionResult FootballLeagueInfo(int competitionId)
        {
            FootballLeagueInfoViewModel vm = new FootballLeagueInfoViewModel();
            vm.LeagueRankingInfo = new FootballLeagueRankingInfoViewModel();
            vm.LeagueRankingInfo.CompetitionId = competitionId;
            vm.Countries = this._homeService.GetLocationsByType(LocationType.Country);

            return View(vm);
        }

        public ActionResult FootballTeamsCompareInfo(long matchId)
        {
            this.ViewBag.Countries = this._homeService.GetLocationsByType(LocationType.Country);
            FootballTeamsCompareInfoViewModel vm = this._homeService.GetFootballCompareInfo(matchId);

            return this.View(vm);
        }

        public PartialViewResult FootballTeamsCompareInfoDetails(int hostTeamId, int visitorTeamId, MatchCompareType type, int topRows)
        {
            FootballTeamsCompareInfoDetailsViewModel vm = this._homeService.GetLastFootballMatches(hostTeamId, visitorTeamId, type, topRows);
            vm.CompareType = type;
            
            return PartialView("_FootballTeamsCompareInfoH2HTables", vm);
        }
    }
}