using MilitaryNuclearAccident.Src.Mna.Common.Dtos;
using MilitaryNuclearAccident.Src.Mna.Common.Enum;

namespace MilitaryNuclearAccident.Src.Mna.Services.Interfaces
{
    public interface ILocationService
    {

        Task<IEnumerable<LocationResponse>> GetLocationAsync();

        Task<LocationResponse?> GetSingleLocationAsync(Guid locationId);

        Task<IEnumerable<LocationResponse?>> GetBrokenArrowsByLocationAsync(AvailableLocation availableLocation);

    }
}
