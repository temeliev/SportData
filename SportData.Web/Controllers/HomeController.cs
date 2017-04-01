using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportData.Web.Interfaces;
using SportData.Web.Models;
using SportData.Web.Services;

namespace SportData.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeService _service;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _service = new HomeService(unitOfWork);
        }

        [HttpGet]
        public ActionResult Index()
        {
            HomeViewModel home = new HomeViewModel();
            home.Matches = _service.GetMatchesByDate(DateTime.Now);
            return View(home);
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
    }
}