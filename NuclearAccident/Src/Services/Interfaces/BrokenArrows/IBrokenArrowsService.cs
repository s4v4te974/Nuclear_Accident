using NuclearAccident.Src.Common.Dtos;

namespace NuclearAccident.Src.Services.Interfaces.BrokenArrows
{
    public interface IbrokenArrowsService
    {

        Task<IEnumerable<AccidentResponse>> GetAccidentsAsync();

        Task<AccidentResponse?> GetSingleAccidentAsync(Guid AccidentId);

        Task<IEnumerable<AccidentResponse>> GetAccidentsByYearsAsync(int year);

    }
}
