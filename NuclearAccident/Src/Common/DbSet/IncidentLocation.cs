using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NuclearIncident.Src.Common.DbSet
{
    [Table("location")]
    public class Location
    {

        [Key]
        [Column("locationid")]
        public Guid LocationId { get; set; }

        [Column("continent")]
        public string? Continent { get; set; }

        [Column("lostlocation")]
        public string? LostLocation { get; set; }

        [Column("xcoordonate")]
        public float? XCoordonate { get; set; }

        [Column("ycoordonate")]
        public float? YCoordonate { get; set; }

        public List<BrokenArrow>? BrokenArrows { get; set; }

    }
}
