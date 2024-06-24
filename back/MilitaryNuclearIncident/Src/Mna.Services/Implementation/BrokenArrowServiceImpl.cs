using AutoMapper;
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
    public class BrokenArrowServiceImpl(BrokenArrowContext context, Mapper mapper, ILogger<BrokenArrowServiceImpl> logger) : IBrokenArrowService
    {
        private readonly BrokenArrowContext _context = context;
        private readonly Mapper _mapper = mapper;
        private readonly ILogger<BrokenArrowServiceImpl> _logger = logger;

        public async Task<IEnumerable<BrokenArrowResponse>> GetBrokenArrowsAsync()
        {
            try
            {
                List<BrokenArrow> brokenArrows = await _context.BrokenArrows.ToListAsync();
                return brokenArrows != null && brokenArrows.Any() ? _mapper.Map<IEnumerable<BrokenArrowResponse>>(brokenArrows) : [];
            }
            catch (DbException ex)
            {
                _logger.LogError(ex, ConstUtils.ERROR_LOG_BA);
                throw new BrokenArrowException(ConstUtils.UNABLE_TO_RETRIEVE_ALL_BA, ex);
            }
        }

        public async Task<IEnumerable<BrokenArrowResponse>> GetBrokenArrowsByYearsAsync(int year)
        {
            try
            {
                int lastYear = year + 9;
                List<BrokenArrow> brokenArrows = await _context.BrokenArrows
                    .Where(b => b.DisasterDate.Year >= year && b.DisasterDate.Year <= lastYear)
                    .ToListAsync();
                return brokenArrows != null && brokenArrows.Any() ? _mapper.Map<IEnumerable<BrokenArrowResponse>>(brokenArrows) : [];
            }
            catch (DbException ex)
            {
                throw new BrokenArrowException(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_YEAR, ex);
            }

        }

        public async Task<BrokenArrowResponse?> GetSingleBrokenArrowAsync(Guid brokenArrowId)
        {
            try
            {
                BrokenArrow? brokenArrow = await _context.BrokenArrows.SingleOrDefaultAsync(b => b.BrokenArrowId == brokenArrowId);
                return brokenArrow != null ? _mapper.Map<BrokenArrowResponse>(brokenArrow) : null;
            }
            catch (DbException ex)
            {
                throw new BrokenArrowException(ConstUtils.UNABLE_TO_RETRIEVE_SINGLE_BA, ex);
            }
        }
    }
}
