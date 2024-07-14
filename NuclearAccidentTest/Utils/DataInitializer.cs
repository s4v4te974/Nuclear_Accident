using NuclearIncident.Src.Data;

namespace NuclearInccidentTest.Utils
{
    internal static class DataInitializer
    {
        public static void Initialize(NuclearAccidentContext context)
        {
            context.Accidents.RemoveRange(context.Accidents);
            context.Locations.RemoveRange(context.Locations);
            context.Vehicules.RemoveRange(context.Vehicules);
            context.Weapons.RemoveRange(context.Weapons);

            context.SaveChanges();
        }
    }
}


