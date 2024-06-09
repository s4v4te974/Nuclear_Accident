using System.ComponentModel.DataAnnotations;

namespace BrokenArrowApp.Models.Entities
{
    public class Description
    {
        [Key]
        public Guid FullDescriptionId { get; set; }

        public string? FullDescription { get; set; }

        public BrokenArrow? BrokenArrow { get; set; }

    }
}
