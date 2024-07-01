using MilitaryNuclearAccident.Src.Mna.Common.Dtos;
using MilitaryNuclearAccident.Src.Mna.Common.Enum;

namespace MilitaryNuclearAccident.Src.Mna.Services.Interfaces
{
    public interface IVehiculeService
    {

        Task<IEnumerable<VehiculeResponse>> GetVehiculesAsync();

        Task<VehiculeResponse?> GetSingleVehiculeAsync(Guid vehiculeId);

        Task<IEnumerable<VehiculeResponse?>> GetBrokenArrowsByVehiculeAsync(AvailableVehicule availableVehicule);

    }
}
