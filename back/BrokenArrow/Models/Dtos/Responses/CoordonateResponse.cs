namespace BrokenArrow.Models.Dtos.Responses
{
    public class CoordonateResponse
    {
        public Guid CoordonateId { get; set; }

        public string? CountryName { get; set; }

        public string? PositionLost { get; set; }

        public float? XCoordonate { get; set; }

        public float? YCoordonate { get; set; }

        public List<Guid>? BrokenArrowsId { get; set; }
    }
}
