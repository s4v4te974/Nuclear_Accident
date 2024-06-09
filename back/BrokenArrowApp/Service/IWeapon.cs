using BrokenArrowApp.Models.Entities;

namespace BrokenArrowApp.Service
{
    public interface IWeapon
    {

        Task<IEnumerable<Weapon>> retrieveAllWeapons();
    }
}
