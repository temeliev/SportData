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
        private IRepository<FootballPlayer> _footballPlayers;
        private IRepository<FootballPlayerCulture> _footballPlayerCultures;
        private IRepository<FootballTeam> _footballTeams;
        private IRepository<FootballTeamCulture> _footballTeamCultures;
        private IRepository<FootballTeamPlayer> _footballTeamsPlayers;
        private IRepository<PlayerStatus> _playerStatuses;
        private IRepository<CompetitionType> _competitionTypes;

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

        public IRepository<FootballPlayer> FootballPlayers
            =>
                this._footballPlayers ??
                (this._footballPlayers = new Repository<FootballPlayer>(this._context.FootballPlayers));

        public IRepository<FootballPlayerCulture> FootballPlayerCultures
            =>
                this._footballPlayerCultures ??
                (this._footballPlayerCultures = new Repository<FootballPlayerCulture>(this._context.FootballPlayerCultures));

        public IRepository<FootballTeam> FootballTeams
            =>
                this._footballTeams ??
                (this._footballTeams = new Repository<FootballTeam>(this._context.FootballTeams));

        public IRepository<FootballTeamCulture> FootballTeamCultures
            =>
                this._footballTeamCultures ??
                (this._footballTeamCultures = new Repository<FootballTeamCulture>(this._context.FootballTeamCultures));

        public IRepository<FootballTeamPlayer> FootballTeamsPlayers
            =>
                this._footballTeamsPlayers ??
                (this._footballTeamsPlayers = new Repository<FootballTeamPlayer>(this._context.FootballTeamPlayers));

        public IRepository<PlayerStatus> PlayerStatuses
           =>
               this._playerStatuses ??
               (this._playerStatuses = new Repository<PlayerStatus>(this._context.PlayerStatuses));

        public IRepository<CompetitionType> CompetitionTypes
           =>
               this._competitionTypes ??
               (this._competitionTypes = new Repository<CompetitionType>(this._context.CompetitionTypes));

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