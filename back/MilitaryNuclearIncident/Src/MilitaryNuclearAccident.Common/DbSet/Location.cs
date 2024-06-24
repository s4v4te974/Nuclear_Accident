using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrokenArrowApp.Src.BrokenArrowApp.Common.DbSet
{
    [Table("location")]
    public class Location
    {

        [Key]
        [Column("locationid")]
        public Guid LocationId { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("positionlost")]
        public string? PositionLost { get; set; }

        [Column("xcoordonate")]
        public float? XCoordonate { get; set; }

        [Column("ycoordonate")]
        public float? YCoordonate { get; set; }

        public BrokenArrow? BrokenArrow { get; set; }

    }
}
