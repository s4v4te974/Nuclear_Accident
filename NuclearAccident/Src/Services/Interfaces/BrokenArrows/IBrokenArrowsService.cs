using NuclearIncident.Src.Common.Dtos.BrokenArrow;

namespace NuclearIncident.Src.Services.Interfaces.BrokenArrows
{
    public interface IbrokenArrowsService
    {

        Task<IEnumerable<BrokenArrowResponse>> GetBrokenArrowssAsync();

        Task<BrokenArrowResponse?> GetSingleBrokenArrowsAsync(Guid BrokenArrowsId);

        Task<IEnumerable<BrokenArrowResponse>> GetBrokenArrowssByYearsAsync(int year);

    }
}
