using MilitaryNuclearAccident.Src.Mna.Common.Dtos;

namespace MilitaryNuclearAccident.Src.Mna.Services.Interfaces
{
    public interface IStatistiqueService
    {
        Task<StatsResponse> GetAllStatsAsync();
    }
}