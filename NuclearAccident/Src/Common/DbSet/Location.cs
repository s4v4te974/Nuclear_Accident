using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NuclearAccident.Src.Common.DbSet
{
    [Table("location")]
    public class Location
    {

        [Key]
        [Column("locationid")]
        public Guid LocationId { get; set; }

        [Column("country")]
        public string? Country { get; set; }

        [Column("positionlost")]
        public string? PositionLost { get; set; }

        [Column("xcoordonate")]
        public float? XCoordonate { get; set; }

        [Column("ycoordonate")]
        public float? YCoordonate { get; set; }

        public Accident? Accident { get; set; }

    }
}
