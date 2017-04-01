using System.Linq;
using SportData.Data;
using SportData.Data.Entities;

namespace SportData.Web.Interfaces
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SportDataContext _context;
        private IRepository<Match> _matches;
        private IRepository<Location> _locations;
        private IRepository<LocationCulture> _locationCultures;
        private IRepository<CultureDescription> _cultureDescription;

        public UnitOfWork()
        {
            this._context = new SportDataContext();
        }

        public IRepository<Match> Matches
            => this._matches ?? (this._matches = new Repository<Match>(this._context.Matches));

        public IRepository<Location> Locations
            => this._locations ?? (this._locations = new Repository<Location>(this._context.Locations));

        public IRepository<LocationCulture> LocationCultures
            =>
                this._locationCultures ??
                (this._locationCultures = new Repository<LocationCulture>(this._context.LocationCultures));

        public IRepository<CultureDescription> CultureDescription
            =>
                this._cultureDescription ??
                (this._cultureDescription = new Repository<CultureDescription>(this._context.CultureDescription));

        public int SaveChanges()
        {
            return this._context.SaveChanges();
        }

        public void Dispose()
        {
            this._context.Dispose();
        }
    }
}