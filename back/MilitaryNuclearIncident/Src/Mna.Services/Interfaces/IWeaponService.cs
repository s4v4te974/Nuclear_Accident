using MilitaryNuclearAccident.Src.Mna.Common.Dtos;
using MilitaryNuclearAccident.Src.Mna.Common.Enum;

namespace MilitaryNuclearAccident.Src.Mna.Services.Interfaces
{
    public interface IWeaponService
    {

        Task<IEnumerable<WeaponResponse>> GetWeaponsAsync();

        Task<WeaponResponse?> GetSingleWeaponAsync(Guid weaponId);

        Task<IEnumerable<WeaponResponse?>> GetBrokenArrowsByWeaponAsync(AvailableWeapon availableWeapon);
    }
}
