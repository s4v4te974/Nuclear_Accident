namespace BrokenArrowApp.Src.BrokenArrowApp.Common.Dtos
{
    public class LocationResponse
    {
        public Guid LocationId { get; set; }

        public string? Name { get; set; }

        public string? PositionLost { get; set; }

        public float? XCoordonate { get; set; }

        public float? YCoordonate { get; set; }

        public BrokenArrowShortResponse? BrokenArrow { get; set; }
    }
}
