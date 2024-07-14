using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NuclearIncident.Src.Common.DbSet;
using NuclearIncident.Src.Common.Dtos;
using NuclearIncident.Src.Common.Enum;
using NuclearIncident.Src.Common.Exceptions;
using NuclearIncident.Src.Common.Utils;
using NuclearIncident.Src.Data;
using NuclearIncident.Src.Services.Interfaces.Common;
using System.Data.Common;

namespace NuclearIncident.Src.Services.Implementation.Common
{
    public class LocationServiceImpl(NuclearAccidentContext context, IMapper mapper, ILogger<LocationServiceImpl> logger) : ILocationService
    {
        private readonly NuclearAccidentContext _context = context;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<LocationServiceImpl> _logger = logger;

        public async Task<IEnumerable<LocationResponse>> GetLocationAsync()
        {
            try
            {
                List<Location> locations = await _context.Locations
                    .Include(l => l.Accidents)
                    .ToListAsync();
                return locations != null && locations.Any() ? _mapper.Map<IEnumerable<LocationResponse>>(locations).ToList() : [];
            }
            catch (DbException ex)
            {
                _logger.LogError(ex, ConstUtils.ERROR_LOG_COORDONATE);
                throw new NuclearIncidentException(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_LOCATION, ex);
            }
        }

        public async Task<LocationResponse?> GetSingleLocationAsync(Guid locationId)
        {
            try
            {
                Location? location = await _context.Locations
                    .Include(l => l.Accidents)
                    .SingleOrDefaultAsync(l => l.LocationId == locationId);
                return location != null ? _mapper.Map<LocationResponse>(location) : null;
            }
            catch (DbException ex)
            {
                _logger.LogError(ex, ConstUtils.ERROR_LOG_COORDONATE);
                throw new NuclearIncidentException(ConstUtils.UNABLE_TO_RETRIEVE_SPECIFIC_LOCATION, ex);
            }
        }

        public async Task<IEnumerable<LocationResponse?>> GetAccidentsByLocationAsync(AvailableLocation availableLocation)
        {
            try
            {
                string? locationName = Enum.GetName(typeof(AvailableLocation), value: availableLocation);
                if (locationName != null)
                {
                    List<Location> location = await _context.Locations.Where(l => l.Country != null && l.Country.ToLower() == locationName.ToLower())
                        .Include(l => l.Accidents)
                        .ToListAsync();
                    return location != null ? _mapper.Map<IEnumerable<LocationResponse>>(location) : [];
                }
                else
                {
                    return [];
                }
            }
            catch (DbException ex)
            {
                _logger.LogError(ex, ConstUtils.ERROR_LOG_BA);
                throw new NuclearIncidentException(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_LOCATION, ex);
            }
        }
    }
}
