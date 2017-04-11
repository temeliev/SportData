using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Antlr.Runtime.Misc;
using SportData.Data;
using SportData.Web.Interfaces;
using SportData.Web.Models;

namespace SportData.Web.Services
{
    public class HomeService : Service, IHomeService
    {
        public HomeService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public List<MatchViewModel> GetMatchesByDate(DateTime date)
        {
            var result = UnitOfWork.Matches.Where(x => DbFunctions.TruncateTime(x.MatchDate) == date.Date);
            return new ListStack<MatchViewModel>();
        }
    }
}