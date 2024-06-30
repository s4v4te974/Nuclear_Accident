namespace MilitaryNuclearAccident.Src.Mna.Common.Dtos
{
    public class StatsResponse
    {
        public StatsResponse()
        {
            BrokenArrowByVehiculeBuilder = new();
            BrokenArrowByVehiculesType = new();
            BrokenArrowByLocations = new();
            BrokenArrowByWeaponsName = new();
        }

        public Dictionary<string, int>? BrokenArrowByVehiculeBuilder { get; set; }

        public Dictionary<string, int>? BrokenArrowByVehiculesType { get; set; }

        public Dictionary<string, int>? BrokenArrowByLocations { get; set; }

        public Dictionary<string, int>? BrokenArrowByWeaponsName { get; set; }
    }
}