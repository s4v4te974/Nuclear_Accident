using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MilitaryNuclearAccident.Src.Mna.Common.DbSet;
using MilitaryNuclearAccident.Src.Mna.Common.Dtos;
using MilitaryNuclearAccident.Src.Mna.Common.Enum;
using MilitaryNuclearAccident.Src.Mna.Common.Exceptions;
using MilitaryNuclearAccident.Src.Mna.Data;
using MilitaryNuclearAccident.Src.Mna.Services.Interfaces;
using MilitaryNuclearAccident.Src.Mna.UI.Utils;
using System.Data.Common;

namespace MilitaryNuclearAccident.Src.Mna.Services.Implementation
{
    public class VehiculeServiceImpl(BrokenArrowContext context, Mapper mapper, ILogger<VehiculeServiceImpl> logger) : IVehiculeService
    {
        private readonly BrokenArrowContext _context = context;
        private readonly Mapper _mapper = mapper;
        private readonly ILogger<VehiculeServiceImpl> _logger = logger;

        public async Task<IEnumerable<VehiculeResponse>> GetVehiculesAsync()
        {
            try
            {
                List<Vehicule> vehicules = await _context.Vehicules
                    .Include(s => s.BrokenArrows).ToListAsync();
                return vehicules != null && vehicules.Any() ? _mapper.Map<IEnumerable<VehiculeResponse>>(vehicules) : [];
            }
            catch (DbException ex)
            {
                _logger.LogError(ex, ConstUtils.ERROR_LOG_VEHICULE);
                throw new BrokenArrowException(ConstUtils.UNABLE_TO_RETRIEVE_ALL_VEHICULE, ex);
            }
        }

        public async Task<VehiculeResponse?> GetSingleVehiculeAsync(Guid vehiculeId)
        {
            try
            {
                Vehicule? vehicule = await _context.Vehicules
                    .Include(v => v.BrokenArrows)
                    .SingleOrDefaultAsync(s => s.VehiculeId == vehiculeId);
                return vehicule != null ? _mapper.Map<VehiculeResponse>(vehicule) : null;
            }
            catch (DbException ex)
            {
                _logger.LogError(ex, ConstUtils.ERROR_LOG_VEHICULE);
                throw new BrokenArrowException(ConstUtils.UNABLE_TO_RETRIEVE_SPECIFIC_VEHICULE, ex);
            }
        }

        public async Task<IEnumerable<VehiculeResponse?>> GetBrokenArrowsByVehiculeAsync(AvailableVehicule availableVehicule)
        {
            try
            {
                string? vehiculeName = System.Enum.GetName(typeof(AvailableVehicule), value: availableVehicule);
                if (vehiculeName != null)
                {
                    List<Vehicule> vehicules = await _context.Vehicules.Where(v => v.Builder != null && v.Builder.ToLower() == vehiculeName.ToLower())
                        .Include(v => v.BrokenArrows)
                        .ToListAsync();
                    return vehicules != null ? _mapper.Map<IEnumerable<VehiculeResponse>>(vehicules) : [];
                }
                else
                {
                    return [];
                }
            }
            catch (DbException ex)
            {
                _logger.LogError(ex, ConstUtils.ERROR_LOG_BA);
                throw new BrokenArrowException(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_VEHICULE, ex);
            }
        }
    }
}
