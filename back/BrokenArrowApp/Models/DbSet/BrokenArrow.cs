using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrokenArrowApp.Models.Entities
{
    [Table("brokenarrows")]
    public class BrokenArrow
    {

        [Key]
        [Column("brokenarrowid")]
        public Guid BrokenArrowId { get; set; }

        // coordonate
        [Column("coordonateid")]
        public Guid? CoordonateId { get; set; }
        public Coordonate? Coordonate { get; set; }

        // description
        [Column("fulldescriptionid")]
        public Guid? FullDescriptionId { get; set; }
        public Description? Description { get; set; }

        // vehicule
        [Column("vehiculeid")]
        public Guid VehiculeId { get; set; }
        public Vehicule? Vehicule { get; set; }

        // weapon
        [Column("weaponid")]
        public Guid? WeaponId { get; set; }
        public Weapon? Weapon { get; set; }

        [Column("disasterdate")]
        public DateTime DisasterDate { get; set; }

        [Column("shortdescription")]
        public string? ShortDescription { get; set; }

        [Column("bubbledescription")]
        public string? BubbleDescription { get; set; }
    }
}
