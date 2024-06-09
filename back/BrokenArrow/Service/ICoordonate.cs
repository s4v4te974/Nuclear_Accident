using BrokenArrow.Models.Entities;

namespace BrokenArrow.Service
{
    public interface ICoordonate
    {

        Task<IEnumerable<Coordonate>> RetrieveAllCoordonates();

    }
}
