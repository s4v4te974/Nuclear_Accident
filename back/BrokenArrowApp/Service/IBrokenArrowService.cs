using BrokenArrowApp.Models.Entities;

namespace BrokenArrowApp.Service
{
    public interface IBrokenArrowService
    {

        Task<IEnumerable<BrokenArrow>> RetrieveAllBrokenArrows();

        Task<BrokenArrow?> RetrieveSpecificBrokenArrow(Guid brokenArrowId);

        Task<IEnumerable<BrokenArrow>> RetrieveBrokenArrowsByYears(int year);

        Task<IEnumerable<BrokenArrow>> RetrieveBrokenArrowsByWeapon(Guid weaponId);

        Task<IEnumerable<BrokenArrow>> RetrieveAllBrokenArrowsByCoordonate(Guid coordonate);

        Task<IEnumerable<BrokenArrow>> RetrieveBrokenArrowsByVehicule(Guid vehiculeId);

    }
}
