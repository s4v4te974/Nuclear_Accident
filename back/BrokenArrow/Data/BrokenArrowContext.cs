﻿using BrokenArrow.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace BrokenArrow.Data
{
    public class BrokenArrowContext : DbContext
    {

        public BrokenArrowContext(DbContextOptions<BrokenArrowContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // relation between BA and Description (one-to-one)
            modelBuilder.Entity<BrokenArrow>()
                .HasOne(b => b.Description)
                .WithOne(d => d.BrokenArrow)
                .HasForeignKey<Description>(d => d.FullDescriptionId)
                .IsRequired(false);

            // relation between BA and Coordonate (one-to-one)
            modelBuilder.Entity<BrokenArrow>()
                .HasOne(b => b.Coordonate)
                .WithOne(d => d.BrokenArrow)
                .HasForeignKey<Coordonate>(d => d.CoordonateId)
                .IsRequired(false);

            // relation between BA and Weapon (one to many)
            modelBuilder.Entity<BrokenArrow>()
                .HasOne(w => w.Weapon)
                .WithMany(d => d.BrokenArrows)
                .HasForeignKey(w => w.WeaponId)
                .IsRequired(false);

            // relation between BA and Plane (one to many)
            modelBuilder.Entity<BrokenArrow>()
                .HasOne(v => v.Vehicule)
                .WithMany(d => d.BrokenArrows)
                .HasForeignKey(v => v.VehiculeId)
                .IsRequired(false);
        }

        public DbSet<Models.Entities.BrokenArrow> BrokenArrows { get; set; }

        public DbSet<Coordonate> Coordonates { get; set; }

        public DbSet<Description> Description { get; set; }

        public DbSet<Vehicule> Vehicules { get; set; }

        public DbSet<Weapon> Weapons { get; set; }


    }
}
