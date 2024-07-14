using NuclearAccident.Src.Common.Dtos;

namespace NuclearAccident.Src.Services.Interfaces.BrokenArrows
{
    public interface IBrokenArrowsStatistiqueService
    {
        Task<StatsResponse> GetAllStatsAsync();
    }
}