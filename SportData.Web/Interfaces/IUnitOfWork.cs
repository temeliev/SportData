using System;
using System.Data.Entity.Core.Objects;
using SportData.Data.Entities;

namespace SportData.Web.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Match> Matches { get; }

        IRepository<Location> Locations { get; }

        IRepository<LocationCulture> LocationCultures { get; }

        IRepository<CultureDescription> CultureDescription { get; }

        int SaveChanges();

        void ReloadContext();
    }
}