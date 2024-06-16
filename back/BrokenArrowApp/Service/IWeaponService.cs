using BrokenArrowApp.Models.Dtos;

namespace BrokenArrowApp.Service
{
    public interface IWeaponService
    {

        Task<IEnumerable<WeaponResponse>> GetWeaponAsync();

        Task<WeaponResponse?> GetSingleWeaponAsync(Guid weaponId);
    }
}
