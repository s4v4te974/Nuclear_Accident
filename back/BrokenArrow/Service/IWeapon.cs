using BrokenArrow.Models.Entities;

namespace BrokenArrow.Service
{
    public interface IWeapon
    {

        Task<IEnumerable<Weapon>> retrieveAllWeapons();
    }
}
