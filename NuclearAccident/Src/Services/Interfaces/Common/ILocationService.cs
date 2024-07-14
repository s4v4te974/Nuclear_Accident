using NuclearIncident.Src.Common.Dtos;
using NuclearIncident.Src.Common.Enum;

namespace NuclearIncident.Src.Services.Interfaces.Common
{
    public interface ILocationService
    {

        Task<IEnumerable<LocationResponse>> GetLocationAsync();

        Task<LocationResponse?> GetSingleLocationAsync(Guid locationId);

        Task<IEnumerable<LocationResponse?>> GetAccidentsByLocationAsync(AvailableLocation availableLocation);

    }
}
