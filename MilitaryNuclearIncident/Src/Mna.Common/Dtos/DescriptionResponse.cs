namespace MilitaryNuclearAccident.Src.Mna.Common.Dtos
{
    public class DescriptionResponse
    {
        public Guid FullDescriptionId { get; set; }

        public string? FullDescription { get; set; }

        public Guid? BrokenArrowId { get; set; }
    }
}
