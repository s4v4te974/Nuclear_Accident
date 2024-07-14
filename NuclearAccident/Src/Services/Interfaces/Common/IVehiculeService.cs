using NuclearAccident.Src.Common.Dtos;
using NuclearAccident.Src.Common.Enum;

namespace NuclearAccident.Src.Services.Interfaces.Common
{
    public interface IVehiculeService
    {

        Task<IEnumerable<VehiculeResponse>> GetVehiculesAsync();

        Task<VehiculeResponse?> GetSingleVehiculeAsync(Guid vehiculeId);

        Task<IEnumerable<VehiculeResponse?>> GetAccidentsByVehiculeAsync(AvailableVehicule availableVehicule);

    }
}
