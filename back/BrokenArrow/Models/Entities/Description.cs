using System.ComponentModel.DataAnnotations;

namespace BrokenArrow.Models.Entities
{
    public class Description
    {
        [Key]
        public Guid FullDescriptionId { get; set; }

        public string? FullDescription { get; set; }

        public BrokenArrows? BrokenArrow { get; set; }

    }
}
