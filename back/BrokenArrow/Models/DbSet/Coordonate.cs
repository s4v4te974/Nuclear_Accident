using System.ComponentModel.DataAnnotations;

namespace BrokenArrow.Models.Entities
{
    public class Coordonate
    {

        [Key]
        public Guid CoordonateId { get; set; }

        public string? CountryName { get; set; }

        public string? PositionLost { get; set; }

        public float? XCoordonate { get; set; }

        public float? YCoordonate { get; set; }

        public BrokenArrow? BrokenArrow { get; set; }

    }
}
