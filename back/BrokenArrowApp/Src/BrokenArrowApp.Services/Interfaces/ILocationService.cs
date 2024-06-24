using BrokenArrowApp.Src.BrokenArrowApp.Common.Dtos;
using BrokenArrowApp.Src.BrokenArrowApp.Common.Enum;

namespace BrokenArrowApp.Src.BrokenArrowApp.Services.Interfaces
{
    public interface ILocationService
    {

        Task<IEnumerable<LocationResponse>> GetLocationAsync();

        Task<LocationResponse?> GetSingleLocationAsync(Guid locationId);

        Task<IEnumerable<LocationResponse?>> GetBrokenArrowsByLocationAsync(AvailableLocation availableLocation);

    }
}
