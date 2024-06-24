using BrokenArrowApp.Src.BrokenArrowApp.Common.Dtos;

namespace BrokenArrowApp.Src.BrokenArrowApp.Services.Interfaces
{
    public interface IBrokenArrowService
    {

        Task<IEnumerable<BrokenArrowResponse>> GetBrokenArrowsAsync();

        Task<BrokenArrowResponse?> GetSingleBrokenArrowAsync(Guid brokenArrowId);

        Task<IEnumerable<BrokenArrowResponse>> GetBrokenArrowsByYearsAsync(int year);

    }
}
