namespace NuclearAccident.Src.Common.Dtos
{
    public class StatsResponse
    {

        public Dictionary<string, int> AccidentByVehiculeBuilder { get; set; } = new();

        public Dictionary<string, int> AccidentByVehiculesType { get; set; } = new();

        public Dictionary<string, int> AccidentByLocations { get; set; } = new();

        public Dictionary<string, int> AccidentByWeaponsName { get; set; } = new();
    }
}