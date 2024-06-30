using MilitaryNuclearAccident.Src.Mna.Data;


namespace MilitaryNuclearAccidentTest.Utils
{
    internal static class DataInitializer
    {
        public static void Initialize(BrokenArrowContext context)
        {
            context.BrokenArrows.RemoveRange(context.BrokenArrows);
            context.Descriptions.RemoveRange(context.Descriptions);
            context.Locations.RemoveRange(context.Locations);
            context.Vehicules.RemoveRange(context.Vehicules);
            context.Weapons.RemoveRange(context.Weapons);

            context.SaveChanges();
        }
    }
}


