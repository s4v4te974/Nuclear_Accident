using NuclearIncident.Src.Common.Dtos;

namespace NuclearIncident.Src.Services.Interfaces.BrokenArrows
{
    public interface IbrokenArrowsService
    {

        Task<IEnumerable<AccidentResponse>> GetAccidentsAsync();

        Task<AccidentResponse?> GetSingleAccidentAsync(Guid AccidentId);

        Task<IEnumerable<AccidentResponse>> GetAccidentsByYearsAsync(int year);

    }
}
