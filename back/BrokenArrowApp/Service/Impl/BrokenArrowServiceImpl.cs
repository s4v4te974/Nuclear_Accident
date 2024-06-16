using AutoMapper;
using BrokenArrowApp.Data;
using BrokenArrowApp.Exceptions;
using BrokenArrowApp.Models.Dtos;
using BrokenArrowApp.Models.Entities;
using BrokenArrowApp.Utils;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace BrokenArrowApp.Service.Impl
{
    public class BrokenArrowServiceImpl(BrokenArrowContext context, Mapper mapper, ILogger<BrokenArrowServiceImpl> logger) : IBrokenArrowService
    {
        private readonly BrokenArrowContext _context = context;
        private readonly Mapper _mapper = mapper;
        private readonly ILogger<BrokenArrowServiceImpl> _logger = logger;

        public async Task<IEnumerable<BrokenArrowResponse>> GetAllBrokenArrowsAsync()
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

        public async Task<IEnumerable<BrokenArrowResponse>> GetAllBrokenArrowsByCoordonateAsync(Guid coordonate)
        {
            try
            {
                List<BrokenArrow> brokenArrows = await _context.BrokenArrows.Where(b => b.CoordonateId == coordonate).ToListAsync();
                return brokenArrows != null && brokenArrows.Any() ? _mapper.Map<IEnumerable<BrokenArrowResponse>>(brokenArrows) : [];
            }
            catch (DbException ex)
            {
                _logger.LogError(ex, ConstUtils.ERROR_LOG_BA);
                throw new BrokenArrowException(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_COORDONATE, ex);
            }
        }

        public async Task<IEnumerable<BrokenArrowResponse>> GetBrokenArrowsByVehiculeAsync(Guid vehiculeId)
        {
            try
            {
                List<BrokenArrow> brokenArrows = await _context.BrokenArrows.Where(b => b.VehiculeId == vehiculeId).ToListAsync();
                return brokenArrows != null && brokenArrows.Any() ? _mapper.Map<IEnumerable<BrokenArrowResponse>>(brokenArrows) : [];
            }
            catch (DbException ex)
            {
                _logger.LogError(ex, ConstUtils.ERROR_LOG_BA);
                throw new BrokenArrowException(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_VEHICULE, ex);
            }
        }

        public async Task<IEnumerable<BrokenArrowResponse>> GetBrokenArrowsByWeaponAsync(Guid weaponId)
        {
            try
            {
                List<BrokenArrow> brokenArrows = await _context.BrokenArrows.Where(b => b.WeaponId == weaponId).ToListAsync();
                return brokenArrows != null && brokenArrows.Any() ? _mapper.Map<IEnumerable<BrokenArrowResponse>>(brokenArrows) : [];
            }
            catch (DbException ex)
            {
                _logger.LogError(ex, ConstUtils.ERROR_LOG_BA);
                throw new BrokenArrowException(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_WEAPON, ex);
            }
        }

        public async Task<IEnumerable<BrokenArrowResponse>> GetBrokenArrowsByYearsAsync(int year)
        {
            try
            {
                List<BrokenArrow> brokenArrows = await _context.BrokenArrows.Where(b => b.DisasterDate.Year == year).ToListAsync();
                return brokenArrows != null && brokenArrows.Any() ? _mapper.Map<IEnumerable<BrokenArrowResponse>>(brokenArrows) : [];
            }
            catch (DbException ex)
            {
                throw new BrokenArrowException(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_YEAR, ex);
            }

        }

        public async Task<BrokenArrowResponse?> GetSpecificBrokenArrowAsync(Guid brokenArrowId)
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
