using HomeXTest.Domain.Models;

namespace HomeXTest.Repository
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HomeXTestDbContext : DbContext
    {
        public HomeXTestDbContext()
            : base("name=HomeXTestDbContext")
        {
        }

        public virtual DbSet<Activity> activities { get; set; }
        public virtual DbSet<ActivitiesPeople> activities_people { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Activity>()
                .HasMany(e => e.activities_people)
                .WithOptional(e => e.activity)
                .HasForeignKey(e => e.activity_id);
        }
    }
}
