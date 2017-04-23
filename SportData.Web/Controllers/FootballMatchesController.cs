using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        // GET: FootballMatches
        public PartialViewResult FootballMatches(string date, MatchStatus status)
        {
            //var dateList = _homeService.GetDateList();
            //ViewBag.DateList = dateList;
            FootballMatchesViewModel vm = new FootballMatchesViewModel();
            DateTime selectedDate = _homeService.GetDateFromString(date);
            vm.Matches = _homeService.GetMatchesByDate(selectedDate, status);
            vm.MatchStatus = status;
            //vm.SelectedDate = dateList[6].Text;//Current date
            //ViewBag.DateList = dateList;

            return PartialView("_FootballMatchesTable", vm);
        }
    }
}