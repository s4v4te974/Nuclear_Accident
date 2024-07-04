using NuclearAccident.Src.Common.Dtos;
using NuclearAccident.Src.Common.Enum;

namespace NuclearAccident.Src.Services.Interfaces
{
    public interface ILocationService
    {

        Task<IEnumerable<LocationResponse>> GetLocationAsync();

        Task<LocationResponse?> GetSingleLocationAsync(Guid locationId);

        Task<IEnumerable<LocationResponse?>> GetAccidentsByLocationAsync(AvailableLocation availableLocation);

    }
}
