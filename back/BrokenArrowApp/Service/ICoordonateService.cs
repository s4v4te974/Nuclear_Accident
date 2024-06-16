using BrokenArrowApp.Models.Dtos;

namespace BrokenArrowApp.Service
{
    public interface ICoordonateService
    {

        Task<IEnumerable<CoordonateResponse>> GetCoordonatesAsync();

        Task<CoordonateResponse?> GetSingleCoordonateAsync(Guid coordonateId);

    }
}
