using BrokenArrow.Models.Entities;

namespace BrokenArrow.Service
{
    public interface IBrokenArrowService
    {

        Task<IEnumerable<BrokenArrows>> retrieveAllBrokenArrows();

        Task<BrokenArrows> retrieveSpecificBrokenArrow(Guid brokenArrowId);

        Task<IEnumerable<BrokenArrows>> retrieveBrokenArrowsByYears(int year);

        Task<IEnumerable<BrokenArrows>> retrieveBrokenArrowsByWeapon(Guid weaponId);

        Task<IEnumerable<BrokenArrows>> retrieveBrokenArrowsByVehicule(Guid vehiculeId);

    }
}
