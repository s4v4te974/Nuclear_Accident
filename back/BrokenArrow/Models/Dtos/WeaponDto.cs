namespace BrokenArrow.Models.Dtos
{
    public class WeaponDto
    {
        public Guid WeaponId { get; set; }

        public string? Name { get; set; }

        public string? Builder { get; set; }

        public string? WeaponDescription { get; set; }

        public List<Guid>? BrokenArrowsId { get; set; }
    }
}
