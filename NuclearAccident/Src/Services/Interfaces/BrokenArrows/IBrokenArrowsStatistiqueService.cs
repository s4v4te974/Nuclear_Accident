using NuclearIncident.Src.Common.Dtos;

namespace NuclearIncident.Src.Services.Interfaces.BrokenArrows
{
    public interface IBrokenArrowsStatistiqueService
    {
        Task<AccidentStatsResponse> GetAllStatsAsync();
    }
}