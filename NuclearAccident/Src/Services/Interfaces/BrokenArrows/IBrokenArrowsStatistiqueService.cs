using NuclearIncident.Src.Common.Dtos.BrokenArrow;

namespace NuclearIncident.Src.Services.Interfaces.BrokenArrows
{
    public interface IBrokenArrowsStatistiqueService
    {
        Task<BrokenArrowStatsResponse> GetAllStatsAsync();
    }
}