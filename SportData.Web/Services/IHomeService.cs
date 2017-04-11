using System;
using System.Collections.Generic;
using SportData.Web.Interfaces;
using SportData.Web.Models;

namespace SportData.Web.Services
{
    public interface IHomeService
    {
        List<MatchViewModel> GetMatchesByDate(DateTime date);

        IUnitOfWork UnitOfWork { get; }
    }
}
