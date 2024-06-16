namespace BrokenArrowApp.Models.Dtos
{
    public class CoordonateResponse
    {
        public Guid CoordonateId { get; set; }

        public string? CountryName { get; set; }

        public string? PositionLost { get; set; }

        public float? XCoordonate { get; set; }

        public float? YCoordonate { get; set; }

        public BrokenArrowShortResponse? BrokenArrow { get; set; }
    }
}
