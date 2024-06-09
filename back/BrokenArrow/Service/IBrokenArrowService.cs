using BrokenArrow.Models.Entities;

namespace BrokenArrow.Service
{
    public interface IBrokenArrowService
    {

        Task<IEnumerable<BrokenArrows>> RetrieveAllBrokenArrows();

        Task<BrokenArrows?> RetrieveSpecificBrokenArrow(Guid brokenArrowId);

        Task<IEnumerable<BrokenArrows>> RetrieveBrokenArrowsByYears(int year);

        Task<IEnumerable<BrokenArrows>> RetrieveBrokenArrowsByWeapon(Guid weaponId);

        Task<IEnumerable<BrokenArrows>> RetrieveBrokenArrowsByVehicule(Guid vehiculeId);

    }
}
