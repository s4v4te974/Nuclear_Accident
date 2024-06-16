using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrokenArrowApp.Models.Entities
{
    [Table("coordonate")]
    public class Coordonate
    {

        [Key]
        [Column("coordonateid")]
        public Guid CoordonateId { get; set; }

        [Column("countryname")]
        public string? CountryName { get; set; }

        [Column("positionlost")]
        public string? PositionLost { get; set; }

        [Column("xcoordonate")]
        public float? XCoordonate { get; set; }

        [Column("ycoordonate")]
        public float? YCoordonate { get; set; }

        public BrokenArrow? BrokenArrow { get; set; }

    }
}
