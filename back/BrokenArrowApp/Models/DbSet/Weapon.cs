using System.ComponentModel.DataAnnotations;

namespace BrokenArrowApp.Models.Entities
{
    public class Weapon
    {

        [Key]
        public Guid WeaponId { get; set; }

        public string? Name { get; set; }

        public string? Builder { get; set; }

        public string? WeaponDescription { get; set; }

        public List<BrokenArrow>? BrokenArrows { get; set; }
    }
}
