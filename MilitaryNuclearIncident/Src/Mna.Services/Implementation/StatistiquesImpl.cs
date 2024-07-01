using Microsoft.EntityFrameworkCore;
using MilitaryNuclearAccident.Src.Mna.Common.DbSet;
using MilitaryNuclearAccident.Src.Mna.Common.Dtos;
using MilitaryNuclearAccident.Src.Mna.Common.Exceptions;
using MilitaryNuclearAccident.Src.Mna.Data;
using MilitaryNuclearAccident.Src.Mna.Services.Interfaces;
using MilitaryNuclearAccident.Src.Mna.UI.Utils;
using System.Data.Common;

namespace MilitaryNuclearAccident.Src.Mna.Services.Implementation
{
    public class StatistiquesImpl(BrokenArrowContext context, ILogger<StatistiquesImpl> logger) : IStatistiqueService
    {
        private readonly BrokenArrowContext _context = context;
        private readonly ILogger<StatistiquesImpl> _logger = logger;

        public async Task<StatsResponse> GetAllStatsAsync()
        {
            try
            {
                List<BrokenArrow> brokenArrows = await _context.BrokenArrows
                    .Include(b => b.Weapon).Include(b => b.Vehicule)
                    .Include(b => b.Location).Include(b => b.Description).ToListAsync();
                // change to stats

                StatsResponse statsResponse = new StatsResponse();

                statsResponse.BrokenArrowByVehiculeBuilder = brokenArrows
                    .Where(b => b.Vehicule != null)
                    .GroupBy(b => b.Vehicule.Builder)
                    .ToDictionary(g => g.Key, g => g.Count());

                statsResponse.BrokenArrowByVehiculesType = brokenArrows
                    .Where(b => b.Vehicule != null)
                    .GroupBy(b => b.Vehicule.Type)
                    .ToDictionary(g => g.Key, g => g.Count());

                statsResponse.BrokenArrowByLocations = brokenArrows
                    .Where(b => b.Location != null)
                    .GroupBy(b => b.Location.Country)
                    .ToDictionary(g => g.Key, g => g.Count());

                statsResponse.BrokenArrowByWeaponsName = brokenArrows
                    .Where(b => b.Weapon != null)
                    .GroupBy(b => b.Weapon.Name)
                    .ToDictionary(g => g.Key, g => g.Count());

                return statsResponse;
            }
            catch (DbException ex)
            {
                _logger.LogError(ex, ConstUtils.ERROR_LOG_BA);
                throw new MilitaryNuclearAccidentException(ConstUtils.UNABLE_TO_RETRIEVE_ALL_BA, ex);
            }
        }
    }
}
