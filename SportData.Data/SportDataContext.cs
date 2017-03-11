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


        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }
}