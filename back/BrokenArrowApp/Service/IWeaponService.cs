using BrokenArrowApp.Models.Dtos;

namespace BrokenArrowApp.Service
{
    public interface IWeaponService
    {

        Task<IEnumerable<WeaponResponse>> GetAllWeaponAsync();

        Task<WeaponResponse?> GetSpecificWeaponAsync(Guid weaponId);
    }
}
