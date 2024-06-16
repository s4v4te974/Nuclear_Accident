using BrokenArrowApp.Models.Dtos;

namespace BrokenArrowApp.Service
{
    public interface IBrokenArrowService
    {

        Task<IEnumerable<BrokenArrowResponse>> GetAllBrokenArrowsAsync();

        Task<BrokenArrowResponse?> GetSpecificBrokenArrowAsync(Guid brokenArrowId);

        Task<IEnumerable<BrokenArrowResponse>> GetBrokenArrowsByYearsAsync(int year);

        Task<IEnumerable<BrokenArrowResponse>> GetBrokenArrowsByWeaponAsync(Guid weaponId);

        Task<IEnumerable<BrokenArrowResponse>> GetAllBrokenArrowsByCoordonateAsync(Guid coordonate);

        Task<IEnumerable<BrokenArrowResponse>> GetBrokenArrowsByVehiculeAsync(Guid vehiculeId);

    }
}
