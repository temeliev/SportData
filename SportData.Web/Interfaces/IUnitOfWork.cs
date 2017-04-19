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

        IRepository<FootballCompetition> FootballCompetitions { get; }

        IRepository<FootballCompetitionCulture> FootballCompetitionCultures { get; }

        IRepository<FootballPlayer> FootballPlayers { get; }

        IRepository<FootballPlayerCulture> FootballPlayerCultures { get; }

        IRepository<FootballTeam> FootballTeams { get; }

        IRepository<FootballTeamCulture> FootballTeamCultures { get; }

        IRepository<FootballTeamPlayer> FootballTeamsPlayers { get; }

        IRepository<PlayerStatus> PlayerStatuses { get; }

        IRepository<CompetitionType> CompetitionTypes { get; }

        int SaveChanges();

        void ReloadContext();
    }
}