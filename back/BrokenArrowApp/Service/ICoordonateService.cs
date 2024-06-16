using BrokenArrowApp.Models.Dtos;

namespace BrokenArrowApp.Service
{
    public interface ICoordonateService
    {

        Task<IEnumerable<CoordonateResponse>> GetAllCoordonatesAsync();

        Task<CoordonateResponse?> GetSpecificCoordonateAsync(Guid coordonateId);

    }
}
