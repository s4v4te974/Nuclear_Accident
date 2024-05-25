using BrokenArrow.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace BrokenArrow.Data
{
    public class BrokenArrowContext : DbContext
    {

        public BrokenArrowContext(DbContextOptions<BrokenArrowContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BrokenArrows>()
                .HasOne(b => b.Description)
                .WithOne(d => d.BrokenArrow)
                .HasForeignKey<Description>(d => d.FullDescriptionId)
                .IsRequired(false);

            modelBuilder.Entity<BrokenArrows>()
                .HasOne(b => b.Coordonate)
                .WithOne(d => d.BrokenArrow)
                .HasForeignKey<Coordonate>(d => d.CoordonateId)
                .IsRequired(false);

            modelBuilder.Entity<BrokenArrows>()
                .

        }


        public DbSet<BrokenArrows> BrokenArrows { get; set; }

        public DbSet<Coordonate> Coodonates {  get; set; }
        
        public DbSet<Description> Description { get; set; }

        public DbSet<Vehicule> Vehicules { get; set;}

        public DbSet<Weapon> Weapons { get; set; }


    }
}
