﻿using Microsoft.EntityFrameworkCore;
using NuclearIncident.Src.Common.DbSet;
using NuclearIncident.Src.Common.Dtos.BrokenArrow;
using NuclearIncident.Src.Common.Exceptions;
using NuclearIncident.Src.Common.Utils;
using NuclearIncident.Src.Data;
using NuclearIncident.Src.Services.Interfaces.BrokenArrows;
using System.Data.Common;

namespace NuclearIncident.Src.Services.Implementation.BrokenArrows
{
    public class BrokenArrowsStatistiquesImpl(NuclearAccidentContext context, ILogger<BrokenArrowsStatistiquesImpl> logger) : IBrokenArrowsStatistiqueService
    {
        private readonly NuclearAccidentContext _context = context;
        private readonly ILogger<BrokenArrowsStatistiquesImpl> _logger = logger;

        public async Task<BrokenArrowStatsResponse> GetAllStatsAsync()
        {
            try
            {
                List<Accident> brokenArrows = await _context.Accidents
                    .Include(b => b.Weapon).Include(b => b.Vehicule)
                    .Include(b => b.Location).ToListAsync();

                if (brokenArrows != null)
                {
                    return new()
                    {
                        AccidentByVehiculeBuilder = brokenArrows
                    .Where(b => b.Vehicule != null && b.Vehicule.Builder != null)
                    .GroupBy(b => b.Vehicule!.Builder!)
                    .ToDictionary(g => g.Key, g => g.Count()),

                        AccidentByVehiculesType = brokenArrows
                    .Where(b => b.Vehicule != null && b.Vehicule.Type != null)
                    .GroupBy(b => b.Vehicule!.Type!)
                    .ToDictionary(g => g.Key, g => g.Count()),

                        AccidentByLocations = brokenArrows
                    .Where(b => b.Location != null && b.Location.Country != null)
                    .GroupBy(b => b.Location!.Country!)
                    .ToDictionary(g => g.Key, g => g.Count()),

                        AccidentByWeaponsName = brokenArrows
                    .Where(b => b.Weapon != null && b.Weapon.Name != null)
                    .GroupBy(b => b.Weapon!.Name!)
                    .ToDictionary(g => g.Key, g => g.Count())
                    };
                }
                else
                {
                    return null;
                }
            }
            catch (DbException ex)
            {
                _logger.LogError(ex, ConstUtils.ERROR_LOG_BA);
                throw new NuclearIncidentException(ConstUtils.UNABLE_TO_RETRIEVE_ALL_BA, ex);
            }
        }
    }
}
