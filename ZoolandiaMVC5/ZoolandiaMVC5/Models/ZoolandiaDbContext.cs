using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ZoolandiaMVC.Models;

namespace ZoolandiaMVC5.Models
{
    public class ZoolandiaDbContext : DbContext
    {
        public DbSet<Animal> Animal { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Genus> Genus { get; set; }
        public DbSet<Habitat> Habitat { get; set; }
        public DbSet<HabitatType> HabitatType { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Maintenance> Maintenance { get; set; }
        public DbSet<Species> Species { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>()
                .ToTable("Animal")
                .HasKey(a => a.ID);

            modelBuilder.Entity<Employee>()
                .ToTable("Employee")
                .HasKey(e => e.ID);

            modelBuilder.Entity<Genus>()
                .ToTable("Genus")
                .HasKey(g => g.ID);

            modelBuilder.Entity<Habitat>()
                .ToTable("Habitat")
                .HasKey(h => h.ID);

            modelBuilder.Entity<HabitatType>()
                .ToTable("HabitatType")
                .HasKey(ht => ht.ID);

            modelBuilder.Entity<Image>()
                .ToTable("Image")
                .HasKey(i => i.ID);

            modelBuilder.Entity<Maintenance>()
                .ToTable("Maintenance")
                .HasKey(m => m.ID);

            modelBuilder.Entity<Species>()
                .ToTable("Species")
                .HasKey(s => s.ID);

        }
    }
}