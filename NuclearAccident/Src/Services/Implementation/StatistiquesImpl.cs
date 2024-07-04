using Microsoft.EntityFrameworkCore;
using NuclearAccident.Src.Common.DbSet;
using NuclearAccident.Src.Common.Dtos;
using NuclearAccident.Src.Common.Exceptions;
using NuclearAccident.Src.Common.Utils;
using NuclearAccident.Src.Data;
using NuclearAccident.Src.Services.Interfaces;
using System.Data.Common;

namespace NuclearAccident.Src.Services.Implementation
{
    public class StatistiquesImpl(NuclearAccidentContext context, ILogger<StatistiquesImpl> logger) : IStatistiqueService
    {
        private readonly NuclearAccidentContext _context = context;
        private readonly ILogger<StatistiquesImpl> _logger = logger;

        public async Task<StatsResponse> GetAllStatsAsync()
        {
            try
            {
                List<Accident> Accidents = await _context.Accidents
                    .Include(b => b.Weapon).Include(b => b.Vehicule)
                    .Include(b => b.Location).ToListAsync();
                // change to stats

                StatsResponse statsResponse = new StatsResponse();

                statsResponse.AccidentByVehiculeBuilder = Accidents
                    .Where(b => b.Vehicule != null)
                    .GroupBy(b => b.Vehicule.Builder)
                    .ToDictionary(g => g.Key, g => g.Count());

                statsResponse.AccidentByVehiculesType = Accidents
                    .Where(b => b.Vehicule != null)
                    .GroupBy(b => b.Vehicule.Type)
                    .ToDictionary(g => g.Key, g => g.Count());

                statsResponse.AccidentByLocations = Accidents
                    .Where(b => b.Location != null)
                    .GroupBy(b => b.Location.Country)
                    .ToDictionary(g => g.Key, g => g.Count());

                statsResponse.AccidentByWeaponsName = Accidents
                    .Where(b => b.Weapon != null)
                    .GroupBy(b => b.Weapon.Name)
                    .ToDictionary(g => g.Key, g => g.Count());

                return statsResponse;
            }
            catch (DbException ex)
            {
                _logger.LogError(ex, ConstUtils.ERROR_LOG_BA);
                throw new NuclearAccidentException(ConstUtils.UNABLE_TO_RETRIEVE_ALL_BA, ex);
            }
        }
    }
}
