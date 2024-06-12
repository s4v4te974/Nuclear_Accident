using AutoMapper;
using BrokenArrowApp.Data;
using BrokenArrowApp.Exceptions;
using BrokenArrowApp.Models.Dtos.Responses;
using BrokenArrowApp.Models.Entities;
using BrokenArrowApp.Utils;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace BrokenArrowApp.Service.Impl
{
    public class VehiculeServiceImpl(BrokenArrowContext context, Mapper mapper) : IVehiculeService
    {
        private readonly BrokenArrowContext _context = context;
        private readonly Mapper _mapper = mapper;

        public async Task<IEnumerable<VehiculeResponse>> GetAllVehiculesAsync()
        {
            try
            {
                List<Vehicule> vehicules = await _context.Vehicules
                    .Include(s => s.BrokenArrows).ToListAsync();
                return vehicules != null && vehicules.Any() ? _mapper.Map<IEnumerable<VehiculeResponse>>(vehicules) : [];
            }
            catch (DbException ex)
            {
                throw new BrokenArrowException(ConstUtils.UNABLE_TO_RETRIEVE_ALL_VEHICULE, ex);
            }
        }

        public async Task<VehiculeResponse?> GetSpecificVehiculeAsync(Guid vehiculeId)
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
                throw new BrokenArrowException(ConstUtils.UNABLE_TO_RETRIEVE_SPECIFIC_VEHICULE, ex);
            }
        }
    }
}
