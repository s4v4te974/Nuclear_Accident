namespace NuclearAccident.Src.Common.Dtos
{
    public class AccidentResponse
    {
        public Guid AccidentId { get; set; }
        public Guid? LocationId { get; set; }

        public Guid? VehiculeId { get; set; }

        public Guid? WeaponId { get; set; }

        public DateTime DisasterDate { get; set; }

        public string? ShortDescription { get; set; }

        public string? BubbleDescription { get; set; }

        public string? FullDescriptionId { get; set; }

        public Boolean? IsPowerPlant { get; set; }
    }
}
