using NuclearIncident.Src.Common.DbSet;

namespace NuclearIncident.Src.Common.Dtos.BrokenArrow
{
    public class AccidentResponse
    {
        public Guid AccidentId { get; set; }
        public Location? Location { get; set; }

        public Vehicule? Vehicule { get; set; }

        public Weapon? Weapon { get; set; }

        public DateTime DisasterDate { get; set; }

        public string? ShortDescription { get; set; }

        public string? BubbleDescription { get; set; }

        public string? FullDescription { get; set; }

        public bool IsPowerPlant { get; set; }
    }
}
