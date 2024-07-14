using NuclearIncident.Src.Data;

namespace NuclearInccidentTest.Utils
{
    internal static class DataInitializer
    {
        public static void Initialize(NuclearBrokenArrowsContext context)
        {
            context.BrokenArrows.RemoveRange(context.BrokenArrows);
            context.Locations.RemoveRange(context.Locations);
            context.Vehicules.RemoveRange(context.Vehicules);
            context.Weapons.RemoveRange(context.Weapons);

            context.SaveChanges();
        }
    }
}


