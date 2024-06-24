using AutoMapper;
using BrokenArrowApp.Src.BrokenArrowApp.Common.DbSet;
using BrokenArrowApp.Src.BrokenArrowApp.Common.Dtos;
using BrokenArrowApp.Src.BrokenArrowApp.Common.Enum;
using BrokenArrowApp.Src.BrokenArrowApp.Common.Exceptions;
using BrokenArrowApp.Src.BrokenArrowApp.Data;
using BrokenArrowApp.Src.BrokenArrowApp.Services.Interfaces;
using BrokenArrowApp.Src.BrokenArrowApp.UI.Utils;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace BrokenArrowApp.Src.BrokenArrowApp.Services.Implementation
{
    public class LocationServiceImpl(BrokenArrowContext context, Mapper mapper, ILogger<LocationServiceImpl> logger) : ILocationService
    {
        private readonly BrokenArrowContext _context = context;
        private readonly Mapper _mapper = mapper;
        private readonly ILogger<LocationServiceImpl> _logger = logger;

        public async Task<IEnumerable<LocationResponse>> GetLocationAsync()
        {
            try
            {
                List<Location> locations = await _context.Locations
                    .Include(l => l.BrokenArrow)
                    .ToListAsync();
                return locations != null && locations.Any() ? _mapper.Map<IEnumerable<LocationResponse>>(locations).ToList() : [];
            }
            catch (DbException ex)
            {
                _logger.LogError(ex, ConstUtils.ERROR_LOG_COORDONATE);
                throw new BrokenArrowException(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_LOCATION, ex);
            }
        }

        public async Task<LocationResponse?> GetSingleLocationAsync(Guid locationId)
        {
            try
            {
                Location? location = await _context.Locations
                    .Include(l => l.BrokenArrow)
                    .SingleOrDefaultAsync(l => l.LocationId == locationId);
                return location != null ? _mapper.Map<LocationResponse>(location) : null;
            }
            catch (DbException ex)
            {
                _logger.LogError(ex, ConstUtils.ERROR_LOG_COORDONATE);
                throw new BrokenArrowException(ConstUtils.UNABLE_TO_RETRIEVE_SPECIFIC_LOCATION, ex);
            }
        }

        public async Task<IEnumerable<LocationResponse?>> GetBrokenArrowsByLocationAsync(AvailableLocation availableLocation)
        {
            try
            {
                string? locationName = System.Enum.GetName(typeof(AvailableLocation), value: availableLocation);
                if (locationName != null)
                {
                    List<Location> location = await _context.Locations.Where(l => l.Name != null && l.Name.ToLower() == locationName.ToLower())
                        .Include(l => l.BrokenArrow)
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
                throw new BrokenArrowException(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_LOCATION, ex);
            }
        }
    }
}
