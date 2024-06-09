using System.ComponentModel.DataAnnotations;

namespace BrokenArrow.Models.Entities
{
    public class BrokenArrows
    {

        [Key]
        public Guid BrokenArrowId { get; set; }

        // coordonate
        public Guid? CoordonateId { get; set; }
        public Coordonate? Coordonate { get; set; }

        // description
        public Guid? FullDescriptionId { get; set; }
        public Description? Description { get; set; }

        // vehicule
        public Guid VehiculeId { get; set; }
        public Vehicule? Vehicule { get; set; }

        // weapon
        public Guid? WeaponId { get; set; }
        public Weapon? Weapon { get; set; }


        public DateTime DisasterDate { get; set; }

        public string? ShortDescription { get; set; }

        public string? BubbleDescription { get; set; }
    }
}
