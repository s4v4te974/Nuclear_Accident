using BrokenArrowApp.Models.Dtos;

namespace BrokenArrowApp.Service
{
    public interface IBrokenArrowService
    {

        Task<IEnumerable<BrokenArrowResponse>> GetBrokenArrowsAsync();

        Task<BrokenArrowResponse?> GetSingleBrokenArrowAsync(Guid brokenArrowId);

        Task<IEnumerable<BrokenArrowResponse>> GetBrokenArrowsByYearsAsync(int year);

        Task<IEnumerable<BrokenArrowResponse>> GetBrokenArrowsByWeaponAsync(Guid weaponId);

        Task<IEnumerable<BrokenArrowResponse>> GetBrokenArrowsByCoordonateAsync(Guid coordonate);

        Task<IEnumerable<BrokenArrowResponse>> GetBrokenArrowsByVehiculeAsync(Guid vehiculeId);

    }
}
