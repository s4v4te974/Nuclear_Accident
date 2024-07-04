using NuclearAccident.Src.Common.Dtos;
using NuclearAccident.Src.Common.Enum;

namespace NuclearAccident.Src.Services.Interfaces
{
    public interface IWeaponService
    {

        Task<IEnumerable<WeaponResponse>> GetWeaponsAsync();

        Task<WeaponResponse?> GetSingleWeaponAsync(Guid weaponId);

        Task<IEnumerable<WeaponResponse?>> GetAccidentsByWeaponAsync(AvailableWeapon availableWeapon);
    }
}
