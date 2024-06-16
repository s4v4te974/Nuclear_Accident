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
    public class CoordonateServiceImpl(BrokenArrowContext context, Mapper mapper, ILogger<CoordonateServiceImpl> logger) : ICoordonateService
    {
        private readonly BrokenArrowContext _context = context;
        private readonly Mapper _mapper = mapper;
        private readonly ILogger<CoordonateServiceImpl> _logger = logger;

        public async Task<IEnumerable<CoordonateResponse>> GetCoordonatesAsync()
        {
            try
            {
                List<Coordonate> coordonates = await _context.Coordonate
                    .Include(c => c.BrokenArrow).ToListAsync();
                return coordonates != null && coordonates.Any() ? _mapper.Map<IEnumerable<CoordonateResponse>>(coordonates).ToList() : [];
            }
            catch (DbException ex)
            {
                _logger.LogError(ex, ConstUtils.ERROR_LOG_COORDONATE);
                throw new BrokenArrowException(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_COORDONATE, ex);
            }
        }

        public async Task<CoordonateResponse?> GetSingleCoordonateAsync(Guid coordonateId)
        {
            try
            {
                Coordonate? coordonate = await _context.Coordonate
                    .Include(c => c.BrokenArrow)
                    .SingleOrDefaultAsync(s => s.CoordonateId == coordonateId);
                return coordonate != null ? _mapper.Map<CoordonateResponse>(coordonate) : null;
            }
            catch (DbException ex)
            {
                _logger.LogError(ex, ConstUtils.ERROR_LOG_COORDONATE);
                throw new BrokenArrowException(ConstUtils.UNABLE_TO_RETRIEVE_SPECIFIC_COORDONATE, ex);
            }
        }
    }
}
