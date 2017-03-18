using System.Data.Entity.ModelConfiguration.Conventions;
using SportData.Data.Entities;

namespace SportData.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SportDataContext : DbContext
    {
        public SportDataContext()
            : base("name=SportDataContext")
        {
        }


        public virtual DbSet<Match> Matches { get; set; }

        public virtual DbSet<FootballTeam> FootballTeams { get; set; }

        public virtual DbSet<FootballTeamCulture> FootballTeamCultures { get; set; }

        public virtual DbSet<FootballPlayer> FootballPlayers { get; set; }

        public virtual DbSet<FootballPlayerCulture> FootballPlayerCultures { get; set; }

        public virtual DbSet<FootballTeamPlayer> FootballTeamPlayers { get; set; }

        public virtual DbSet<Location> Locations { get; set; }

        public virtual DbSet<LocationCulture> LocationCultures { get; set; }

        public virtual DbSet<AddressInfo> AddressInfo { get; set; }

        public virtual DbSet<FootballCompetition> FootballCompetition { get; set; }

        public virtual DbSet<FootballCompetitionCulture> FootballCompetitionCultures { get; set; }

        public virtual DbSet<Contact> Contacts { get; set; }

        public virtual DbSet<EventType> EventTypes { get; set; }

        public virtual DbSet<MatchEvent> MatchEvents { get; set; }

        public virtual DbSet<MatchStatus> MatchStatuses { get; set; }

        public virtual DbSet<Season> Seasons { get; set; }

        public virtual DbSet<UserAccount> UserAccounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToOneConstraintIntroductionConvention>();
            //modelBuilder.Entity<MatchEvent>()
            //            .Property(p=>p.MatchId)
            //            .
            //modelBuilder.Entity<Match>()
            //            .HasRequired(x => x.HomeTeam)
            //            .WithMany()
            //            .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Match>()
            //            .HasRequired(x => x.AwayTeam)
            //            .WithMany()
            //            .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Match>()
            //           .HasRequired(x => x.Competition)
            //           .WithMany()
            //           .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Match>()
            //           .HasRequired(x => x.Status)
            //           .WithMany()
            //           .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Match>()
            //           .HasRequired(x => x.Season)
            //           .WithMany()
            //           .WillCascadeOnDelete(false);
        }
    }
}