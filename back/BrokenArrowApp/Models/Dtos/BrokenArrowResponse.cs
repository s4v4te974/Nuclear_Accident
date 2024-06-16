namespace BrokenArrowApp.Models.Dtos
{
    public class BrokenArrowResponse
    {
        public Guid BrokenArrowId { get; set; }
        public Guid? CoordonateId { get; set; }

        public Guid? FullDescriptionId { get; set; }

        public Guid VehiculeId { get; set; }

        public Guid? WeaponId { get; set; }

        public DateTime DisasterDate { get; set; }

        public string? ShortDescription { get; set; }

        public string? BubbleDescription { get; set; }
    }
}
