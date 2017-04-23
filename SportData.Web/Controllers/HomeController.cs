using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportData.Data.Enums;
using SportData.Web.Helpers;
using SportData.Web.Interfaces;
using SportData.Web.Models;
using SportData.Web.Services;

namespace SportData.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            HomeViewModel vm = new HomeViewModel();
            var dateList = _homeService.GetDateList();
            vm.Countries = _homeService.GetLocationsByType(LocationType.Country);
            //vm.GroupedMatches = _homeService.GetMatchesByDate(DateTime.Now.AddDays(-1));
            vm.SelectedDate = dateList[6].Text;//Current date
            ViewBag.DateList = dateList;
            return View(vm);
        }

        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SetCulture(string culture)
        {
            // Validate input
            culture = CultureHelper.GetImplementedCulture(culture);
            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
            {
                cookie.Value = culture; // update cookie value
            }
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }

            Response.Cookies.Add(cookie);

            return RedirectToAction("Index");
        }

        public ActionResult GetTest()
        {
             
            return RedirectToAction("Index");
        }
    }
}