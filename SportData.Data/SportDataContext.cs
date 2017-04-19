using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SportData.Data.Entities;
using SportData.Data.Entities.Identity;

namespace SportData.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SportDataContext : IdentityDbContext<ApplicationUser, ApplicationRole, long, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public SportDataContext()
            : base("name=SportDataContext")
        {
        }

        public static SportDataContext Create()
        {
            return new SportDataContext();
        }

        public DbSet<ApplicationUserLogin> UserLogins { get; set; }

        public DbSet<ApplicationUserClaim> UserClaims { get; set; }

        public DbSet<ApplicationUserRole> UserRoles { get; set; }

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

        public virtual DbSet<CultureDescription> CultureDescription { get; set; }

        public virtual DbSet<PlayerStatus> PlayerStatuses { get; set; }

        public virtual DbSet<CompetitionType> CompetitionTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToOneConstraintIntroductionConvention>();

            modelBuilder.Entity<ApplicationUser>().ToTable("IdentityUsers");
            modelBuilder.Entity<ApplicationUser>().Property(u => u.PasswordHash).HasMaxLength(500);
            modelBuilder.Entity<ApplicationUser>().Property(u => u.SecurityStamp).HasMaxLength(500);
            modelBuilder.Entity<ApplicationUser>().Property(u => u.PhoneNumber).HasMaxLength(50);

            modelBuilder.Entity<ApplicationRole>().ToTable("IdentityRoles");
            modelBuilder.Entity<ApplicationUserRole>().ToTable("IdentityUsersRoles");
            modelBuilder.Entity<ApplicationUserLogin>().ToTable("IdentityUsersLogins");
            modelBuilder.Entity<ApplicationUserClaim>().ToTable("IdentityUsersClaims");
            modelBuilder.Entity<ApplicationUserClaim>().Property(u => u.ClaimType).HasMaxLength(150);
            modelBuilder.Entity<ApplicationUserClaim>().Property(u => u.ClaimValue).HasMaxLength(500);


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