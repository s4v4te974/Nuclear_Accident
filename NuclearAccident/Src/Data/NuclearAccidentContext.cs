using Microsoft.EntityFrameworkCore;
using NuclearAccident.Src.Common.DbSet;


namespace NuclearAccident.Src.Data
{
    public class NuclearAccidentContext : DbContext
    {

        public NuclearAccidentContext(DbContextOptions<NuclearAccidentContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // relation between BA and Coordonate (one-to-one)
            modelBuilder.Entity<Accident>()
                .HasOne(b => b.Location)
                .WithMany(d => d.BrokenArrows)
                .HasForeignKey(d => d.LocationId)
                .IsRequired(false);

            // relation between BA and Weapon (one to many)
            modelBuilder.Entity<Accident>()
                .HasOne(w => w.Weapon)
                .WithMany(d => d.Accidents)
                .HasForeignKey(w => w.WeaponId)
                .IsRequired(false);

            // relation between BA and Plane (one to many)
            modelBuilder.Entity<Accident>()
                .HasOne(v => v.Vehicule)
                .WithMany(d => d.Accidents)
                .HasForeignKey(v => v.VehiculeId)
                .IsRequired(false);
        }
        public DbSet<Accident> Accidents { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Vehicule> Vehicules { get; set; }

        public DbSet<Weapon> Weapons { get; set; }

    }
}
