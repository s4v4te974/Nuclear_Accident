using BrokenArrowApp.Src.BrokenArrowApp.Common.Dtos;
using BrokenArrowApp.Src.BrokenArrowApp.Common.Enum;

namespace BrokenArrowApp.Src.BrokenArrowApp.Services.Interfaces
{
    public interface IVehiculeService
    {

        Task<IEnumerable<VehiculeResponse>> GetVehiculesAsync();

        Task<VehiculeResponse?> GetSingleVehiculeAsync(Guid vehiculeId);

        Task<IEnumerable<VehiculeResponse?>> GetBrokenArrowsByVehiculeAsync(AvailableVehicule availableVehicule);

    }
}
