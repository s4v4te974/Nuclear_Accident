namespace NuclearIncident.Src.Common.Dtos
{
    public class AccidentShortResponse
    {

        public Guid AccidentId { get; set; }

        public DateTime DisasterDate { get; set; }

        public string? BubbleDescription { get; set; }

    }
}