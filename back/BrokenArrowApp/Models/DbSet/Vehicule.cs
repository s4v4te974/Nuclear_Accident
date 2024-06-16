using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrokenArrowApp.Models.Entities
{
    [Table("vehicule")]
    public class Vehicule
    {

        [Key]
        [Column("vehiculeid")]
        public Guid VehiculeId { get; set; }

        [Column("type")]
        public string? Type { get; set; }

        [Column("builder")]
        public string? Builder { get; set; }

        [Column("name")]
        public string? Name { set; get; }

        [Column("vehiculedescription")]
        public string? VehiculeDescription { set; get; }

        public List<BrokenArrow>? BrokenArrows { get; set; }

    }
}
