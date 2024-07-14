using NuclearIncident.Src.Common.Dtos;
using NuclearIncident.Src.Common.Enum;

namespace NuclearIncident.Src.Services.Interfaces.Common
{
    public interface IVehiculeService
    {

        Task<IEnumerable<VehiculeResponse>> GetVehiculesAsync();

        Task<VehiculeResponse?> GetSingleVehiculeAsync(Guid vehiculeId);

        Task<IEnumerable<VehiculeResponse?>> GetAccidentsByVehiculeAsync(AvailableVehicule availableVehicule);

    }
}
