namespace NuclearAccident.Src.Common.Dtos
{
    public class LocationResponse
    {
        public Guid LocationId { get; set; }

        public string? Country { get; set; }

        public string? PositionLost { get; set; }

        public float? XCoordonate { get; set; }

        public float? YCoordonate { get; set; }

        public AccidentShortResponse? Accident { get; set; }
    }
}
