using SportData.Data.Entities;

namespace SportData.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SportDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(SportDataContext context)
        {
            context.CultureDescription.AddOrUpdate(p => p.Name,
                new CultureDescription() { Name = "bg-BG", ShowText = "BG" },
                new CultureDescription() { Name = "en-US", ShowText = "EN" });
        }
    }
}
