namespace MilitaryNuclearAccident.Src.Mna.Common.Dtos
{
    public class VehiculeResponse
    {
        public Guid VehiculeId { get; set; }

        public string? Type { get; set; }

        public string? Builder { get; set; }

        public string? Name { set; get; }

        public string? Description { set; get; }

        public List<BrokenArrowShortResponse>? BrokenArrows { get; set; }
    }
}
