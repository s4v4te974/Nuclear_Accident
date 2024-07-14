using Microsoft.EntityFrameworkCore;
using NuclearIncident.Src.Common.DbSet;


namespace NuclearIncident.Src.Data
{
    public class NuclearBrokenArrowsContext : DbContext
    {

        public NuclearBrokenArrowsContext(DbContextOptions<NuclearBrokenArrowsContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // relation between BA and Coordonate (one-to-one)
            modelBuilder.Entity<BrokenArrow>()
                .HasOne(b => b.Location)
                .WithMany(d => d.BrokenArrows)
                .HasForeignKey(d => d.LocationId)
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
        public DbSet<BrokenArrow> BrokenArrows { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Vehicule> Vehicules { get; set; }

        public DbSet<Weapon> Weapons { get; set; }

    }
}
