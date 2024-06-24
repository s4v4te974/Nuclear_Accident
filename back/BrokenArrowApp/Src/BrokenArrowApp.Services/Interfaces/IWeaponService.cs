using BrokenArrowApp.Src.BrokenArrowApp.Common.Dtos;
using BrokenArrowApp.Src.BrokenArrowApp.Common.Enum;

namespace BrokenArrowApp.Src.BrokenArrowApp.Services.Interfaces
{
    public interface IWeaponService
    {

        Task<IEnumerable<WeaponResponse>> GetWeaponAsync();

        Task<WeaponResponse?> GetSingleWeaponAsync(Guid weaponId);

        Task<IEnumerable<WeaponResponse?>> GetBrokenArrowsByWeaponAsync(AvailableWeapon availableWeapon);
    }
}
