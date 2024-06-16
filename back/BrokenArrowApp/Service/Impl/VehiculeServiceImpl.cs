﻿using AutoMapper;
using BrokenArrowApp.Data;
using BrokenArrowApp.Exceptions;
using BrokenArrowApp.Models.Dtos;
using BrokenArrowApp.Models.Entities;
using BrokenArrowApp.Utils;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace BrokenArrowApp.Service.Impl
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
                List<Vehicule> vehicules = await _context.Vehicule
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
                Vehicule? vehicule = await _context.Vehicule
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
    }
}
