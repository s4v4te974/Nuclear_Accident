using BrokenArrowApp.Models.Dtos.Responses;

namespace BrokenArrowApp.Service
{
    public interface ICoordonateService
    {

        Task<IEnumerable<CoordonateResponse>> GetAllCoordonatesAsync();

        Task<CoordonateResponse?> GetSpecificCoordonateAsync(Guid coordonateId);

    }
}
