using BrokenArrowApp.Models.Dtos;

namespace BrokenArrowApp.Service
{
    public interface IVehiculeService
    {

        Task<IEnumerable<VehiculeResponse>> GetVehiculesAsync();

        Task<VehiculeResponse?> GetSingleVehiculeAsync(Guid vehiculeId);

    }
}
