using NuclearIncident.Src.Common.Dtos.BrokenArrow;

namespace NuclearIncident.Src.Common.Dtos
{
    public class LocationResponse
    {
        public Guid LocationId { get; set; }

        public string? Country { get; set; }

        public string? PositionLost { get; set; }

        public float? XCoordonate { get; set; }

        public float? YCoordonate { get; set; }

        public List<BrokenArrowsShortResponse>? BrokenArrows { get; set; }
    }
}
