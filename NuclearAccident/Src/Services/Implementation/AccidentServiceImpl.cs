using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NuclearAccident.Src.Common.DbSet;
using NuclearAccident.Src.Common.Dtos;
using NuclearAccident.Src.Common.Exceptions;
using NuclearAccident.Src.Common.Utils;
using NuclearAccident.Src.Data;
using NuclearAccident.Src.Services.Interfaces;
using System.Data.Common;


namespace NuclearAccident.Src.Services.Implementation
{
    public class AccidentServiceImpl(NuclearAccidentContext context, IMapper mapper, ILogger<AccidentServiceImpl> logger) : IAccidentService
    {
        private readonly NuclearAccidentContext _context = context;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<AccidentServiceImpl> _logger = logger;

        public async Task<IEnumerable<AccidentResponse>> GetAccidentsAsync()
        {
            try
            {
                List<Accident> accidents = await _context.Accidents
                    .Include(b => b.Weapon).Include(b => b.Vehicule)
                    .Include(b => b.Location).ToListAsync();
                return accidents != null && accidents.Any() ? _mapper.Map<IEnumerable<AccidentResponse>>(accidents) : [];
            }
            catch (DbException ex)
            {
                _logger.LogError(ex, ConstUtils.ERROR_LOG_BA);
                throw new NuclearAccidentException(ConstUtils.UNABLE_TO_RETRIEVE_ALL_BA, ex);
            }
        }

        public async Task<IEnumerable<AccidentResponse>> GetAccidentsByYearsAsync(int year)
        {
            try
            {
                int lastYear = year + 9;
                List<Accident> Accidents = await _context.Accidents
                    .Where(b => b.DisasterDate.Year >= year && b.DisasterDate.Year <= lastYear)
                    .Include(b => b.Weapon).Include(b => b.Vehicule)
                    .Include(b => b.Location).ToListAsync();
                return Accidents != null && Accidents.Any() ? _mapper.Map<IEnumerable<AccidentResponse>>(Accidents) : [];
            }
            catch (DbException ex)
            {
                throw new NuclearAccidentException(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_YEAR, ex);
            }
        }

        public async Task<AccidentResponse?> GetSingleAccidentAsync(Guid AccidentId)
        {
            try
            {
                Accident? accident = await _context.Accidents.SingleOrDefaultAsync(b => b.AccidentId == AccidentId);
                return accident != null ? _mapper.Map<AccidentResponse>(accident) : null;
            }
            catch (DbException ex)
            {
                throw new NuclearAccidentException(ConstUtils.UNABLE_TO_RETRIEVE_SINGLE_BA, ex);
            }
        }
    }
}
