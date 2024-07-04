namespace NuclearAccident.Src.Common.Dtos
{
    public class StatsResponse
    {
        public StatsResponse()
        {
            AccidentByVehiculeBuilder = new();
            AccidentByVehiculesType = new();
            AccidentByLocations = new();
            AccidentByWeaponsName = new();
        }

        public Dictionary<string, int>? AccidentByVehiculeBuilder { get; set; }

        public Dictionary<string, int>? AccidentByVehiculesType { get; set; }

        public Dictionary<string, int>? AccidentByLocations { get; set; }

        public Dictionary<string, int>? AccidentByWeaponsName { get; set; }
    }
}