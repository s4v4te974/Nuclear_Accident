using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NuclearIncident.Src.Common.DbSet;
using NuclearIncident.Src.Common.Dtos.BrokenArrow;
using NuclearIncident.Src.Common.Exceptions;
using NuclearIncident.Src.Common.Utils;
using NuclearIncident.Src.Data;
using NuclearIncident.Src.Services.Interfaces.BrokenArrows;
using System.Data.Common;


namespace NuclearIncident.Src.Services.Implementation.BrokenArrows
{
    public class BrokenArrowsServiceImpl(NuclearBrokenArrowsContext context, IMapper mapper, ILogger<BrokenArrowsServiceImpl> logger) : IbrokenArrowsService
    {
        private readonly NuclearBrokenArrowsContext _context = context;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<BrokenArrowsServiceImpl> _logger = logger;

        public async Task<IEnumerable<BrokenArrowResponse>> GetBrokenArrowssAsync()
        {
            try
            {
                List<BrokenArrow> brokenArrows = await _context.BrokenArrows
                    .Include(b => b.Weapon)
                    .Include(b => b.Vehicule)
                    .Include(b => b.Location)
                    .ToListAsync();
                return brokenArrows != null && brokenArrows.Any() ? _mapper.Map<IEnumerable<BrokenArrowResponse>>(brokenArrows) : [];
            }
            catch (DbException ex)
            {
                _logger.LogError(ex, ConstUtils.ERROR_LOG_BA);
                throw new NuclearIncidentException(ConstUtils.UNABLE_TO_RETRIEVE_ALL_BA, ex);
            }
        }

        public async Task<IEnumerable<BrokenArrowResponse>> GetBrokenArrowssByYearsAsync(int year)
        {
            try
            {
                int lastYear = year + 9;
                List<BrokenArrow> BrokenArrowss = await _context.BrokenArrows
                    .Where(b => b.DisasterDate.Year >= year && b.DisasterDate.Year <= lastYear)
                    .Include(b => b.Weapon).Include(b => b.Vehicule)
                    .Include(b => b.Location).ToListAsync();
                return BrokenArrowss != null && BrokenArrowss.Any() ? _mapper.Map<IEnumerable<BrokenArrowResponse>>(BrokenArrowss) : [];
            }
            catch (DbException ex)
            {
                throw new NuclearIncidentException(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_YEAR, ex);
            }
        }

        public async Task<BrokenArrowResponse?> GetSingleBrokenArrowsAsync(Guid BrokenArrowsId)
        {
            try
            {
                BrokenArrow? BrokenArrows = await _context.BrokenArrows.SingleOrDefaultAsync(b => b.BrokenArrowsId == BrokenArrowsId);
                return BrokenArrows != null ? _mapper.Map<BrokenArrowResponse>(BrokenArrows) : null;
            }
            catch (DbException ex)
            {
                throw new NuclearIncidentException(ConstUtils.UNABLE_TO_RETRIEVE_SINGLE_BA, ex);
            }
        }
    }
}
