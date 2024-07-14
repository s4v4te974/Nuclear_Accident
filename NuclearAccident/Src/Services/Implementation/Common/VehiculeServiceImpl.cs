using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NuclearAccident.Src.Common.DbSet;
using NuclearAccident.Src.Common.Dtos;
using NuclearAccident.Src.Common.Enum;
using NuclearAccident.Src.Common.Exceptions;
using NuclearAccident.Src.Common.Utils;
using NuclearAccident.Src.Data;
using NuclearAccident.Src.Services.Interfaces.Common;
using System.Data.Common;

namespace NuclearAccident.Src.Services.Implementation.Common
{
    public class VehiculeServiceImpl(NuclearAccidentContext context, IMapper mapper, ILogger<VehiculeServiceImpl> logger) : IVehiculeService
    {
        private readonly NuclearAccidentContext _context = context;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<VehiculeServiceImpl> _logger = logger;

        public async Task<IEnumerable<VehiculeResponse>> GetVehiculesAsync()
        {
            try
            {
                List<Vehicule> vehicules = await _context.Vehicules
                    .Include(s => s.Accidents).ToListAsync();
                return vehicules != null && vehicules.Any() ? _mapper.Map<IEnumerable<VehiculeResponse>>(vehicules) : [];
            }
            catch (DbException ex)
            {
                _logger.LogError(ex, ConstUtils.ERROR_LOG_VEHICULE);
                throw new NuclearInccidentException(ConstUtils.UNABLE_TO_RETRIEVE_ALL_VEHICULE, ex);
            }
        }

        public async Task<VehiculeResponse?> GetSingleVehiculeAsync(Guid vehiculeId)
        {
            try
            {
                Vehicule? vehicule = await _context.Vehicules
                    .Include(v => v.Accidents)
                    .SingleOrDefaultAsync(s => s.VehiculeId == vehiculeId);
                return vehicule != null ? _mapper.Map<VehiculeResponse>(vehicule) : null;
            }
            catch (DbException ex)
            {
                _logger.LogError(ex, ConstUtils.ERROR_LOG_VEHICULE);
                throw new NuclearInccidentException(ConstUtils.UNABLE_TO_RETRIEVE_SPECIFIC_VEHICULE, ex);
            }
        }

        public async Task<IEnumerable<VehiculeResponse?>> GetAccidentsByVehiculeAsync(AvailableVehicule availableVehicule)
        {
            try
            {
                string? vehiculeName = Enum.GetName(typeof(AvailableVehicule), value: availableVehicule);
                if (vehiculeName != null)
                {
                    List<Vehicule> vehicules = await _context.Vehicules.Where(v => v.Builder != null && v.Builder.ToLower() == vehiculeName.ToLower())
                        .Include(v => v.Accidents)
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
                throw new NuclearInccidentException(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_VEHICULE, ex);
            }
        }
    }
}
