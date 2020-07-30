using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using racedirector.Data.Models;

namespace racedirector.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Site> Sites { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Classification> Classes { get; set; }
        public DbSet<RaceEntry> RaceEntries { get; set; }
        public DbSet<Run> Runs { get; set; }
        public DbSet<LineCrossing> LineCrossings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (null == modelBuilder)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Site>().ToTable("Sites");
            modelBuilder.Entity<Car>().ToTable("Cars");
            modelBuilder.Entity<Driver>().ToTable("Drivers");
            modelBuilder.Entity<Season>().ToTable("Seasons");
            modelBuilder.Entity<Competition>().ToTable("Competitions");
            modelBuilder.Entity<Organizer>().ToTable("Organizers");
            modelBuilder.Entity<Classification>().ToTable("Classes");
            modelBuilder.Entity<RaceEntry>().ToTable("RaceEntries");
            modelBuilder.Entity<Run>().ToTable("Runs");
            modelBuilder.Entity<LineCrossing>().ToTable("LineCrossings");
        }
    }
}
