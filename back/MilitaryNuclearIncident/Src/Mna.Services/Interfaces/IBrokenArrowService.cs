using MilitaryNuclearAccident.Src.Mna.Common.Dtos;

namespace MilitaryNuclearAccident.Src.Mna.Services.Interfaces
{
    public interface IBrokenArrowService
    {

        Task<IEnumerable<BrokenArrowResponse>> GetBrokenArrowsAsync();

        Task<BrokenArrowResponse?> GetSingleBrokenArrowAsync(Guid brokenArrowId);

        Task<IEnumerable<BrokenArrowResponse>> GetBrokenArrowsByYearsAsync(int year);

    }
}
