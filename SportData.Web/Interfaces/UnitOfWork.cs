using SportData.Data;
using SportData.Data.Entities;

namespace SportData.Web.Interfaces
{
    public class UnitOfWork : IUnitOfWork
    {
        private SportDataContext _context;
        private IRepository<Match> _matches;
        private IRepository<Location> _locations;
        private IRepository<LocationCulture> _locationCultures;
        private IRepository<CultureDescription> _cultureDescription;
        private IRepository<FootballCompetition> _footballCompetitions;
        private IRepository<FootballCompetitionCulture> _footballCompetitionCultures;

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

        public IRepository<FootballCompetition> FootballCompetitions
            =>
                this._footballCompetitions ??
                (this._footballCompetitions = new Repository<FootballCompetition>(this._context.FootballCompetition));

        public IRepository<FootballCompetitionCulture> FootballCompetitionCultures
            =>
                this._footballCompetitionCultures ??
                (this._footballCompetitionCultures = new Repository<FootballCompetitionCulture>(this._context.FootballCompetitionCultures));

        public int SaveChanges()
        {
            return this._context.SaveChanges();
        }

        public void Dispose()
        {
            this._context.Dispose();
        }

        public void ReloadContext()
        {
            this._context = new SportDataContext();
        }
    }
}