using NuclearIncident.Src.Common.Dtos;
using NuclearIncident.Src.Common.Enum;

namespace NuclearIncident.Src.Services.Interfaces.Common
{
    public interface IWeaponService
    {

        Task<IEnumerable<WeaponResponse>> GetWeaponsAsync();

        Task<WeaponResponse?> GetSingleWeaponAsync(Guid weaponId);

        Task<IEnumerable<WeaponResponse?>> GetBrokenArrowssByWeaponAsync(AvailableWeapon availableWeapon);
    }
}
