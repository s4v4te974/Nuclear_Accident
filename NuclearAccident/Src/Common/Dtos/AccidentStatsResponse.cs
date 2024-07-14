namespace NuclearIncident.Src.Common.Dtos
{
    public class AccidentStatsResponse
    {

        public Dictionary<string, int> AccidentByVehiculeBuilder { get; set; } = new();

        public Dictionary<string, int> AccidentByVehiculesType { get; set; } = new();

        public Dictionary<string, int> AccidentByLocations { get; set; } = new();

        public Dictionary<string, int> AccidentByWeaponsName { get; set; } = new();
    }
}