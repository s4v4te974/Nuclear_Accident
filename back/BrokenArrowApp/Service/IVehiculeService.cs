using BrokenArrowApp.Models.Dtos;

namespace BrokenArrowApp.Service
{
    public interface IVehiculeService
    {

        Task<IEnumerable<VehiculeResponse>> GetAllVehiculesAsync();

        Task<VehiculeResponse?> GetSpecificVehiculeAsync(Guid vehiculeId);

    }
}
