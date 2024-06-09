using BrokenArrowApp.Models.Entities;

namespace BrokenArrowApp.Service
{
    public interface ICoordonate
    {

        Task<IEnumerable<Coordonate>> RetrieveAllCoordonates();

    }
}
