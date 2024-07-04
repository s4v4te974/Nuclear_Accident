using NuclearAccident.Src.Common.Dtos;

namespace NuclearAccident.Src.Services.Interfaces
{
    public interface IStatistiqueService
    {
        Task<StatsResponse> GetAllStatsAsync();
    }
}