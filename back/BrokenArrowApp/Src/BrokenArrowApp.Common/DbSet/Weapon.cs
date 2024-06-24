using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrokenArrowApp.Src.BrokenArrowApp.Common.DbSet
{
    [Table("weapon")]
    public class Weapon
    {

        [Key]
        [Column("weaponid")]
        public Guid WeaponId { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("builder")]
        public string? Builder { get; set; }

        [Column("weapondescription")]
        public string? WeaponDescription { get; set; }

        public List<BrokenArrow>? BrokenArrows { get; set; }
    }
}
