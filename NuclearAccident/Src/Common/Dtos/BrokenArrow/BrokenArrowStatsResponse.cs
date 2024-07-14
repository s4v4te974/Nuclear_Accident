namespace NuclearIncident.Src.Common.Dtos.BrokenArrow
{
    public class BrokenArrowStatsResponse
    {

        public Dictionary<string, int> BrokenArrowsByVehiculeBuilder { get; set; } = new();

        public Dictionary<string, int> BrokenArrowsByVehiculesType { get; set; } = new();

        public Dictionary<string, int> BrokenArrowsByLocations { get; set; } = new();

        public Dictionary<string, int> BrokenArrowsByWeaponsName { get; set; } = new();

        public Dictionary<string, int> BrokenArrowByElement { get; set; } = new();
    }
}