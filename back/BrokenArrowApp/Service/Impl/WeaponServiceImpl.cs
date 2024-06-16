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
    public class WeaponServiceImpl(BrokenArrowContext context, Mapper mapper, ILogger<WeaponServiceImpl> logger) : IWeaponService
    {
        private readonly BrokenArrowContext _context = context;
        private readonly Mapper _mapper = mapper;
        private readonly ILogger<WeaponServiceImpl> _logger = logger;
        public async Task<IEnumerable<WeaponResponse>> GetAllWeaponAsync()
        {
            try
            {
                List<Weapon> weapons = await _context.Weapon
                    .Include(s => s.BrokenArrows).ToListAsync();
                return weapons != null && weapons.Any() ? _mapper.Map<IEnumerable<WeaponResponse>>(weapons) : [];
            }
            catch (DbException ex)
            {
                _logger.LogError(ex, ConstUtils.ERROR_LOG_WEAPON);
                throw new BrokenArrowException(ConstUtils.UNABLE_TO_RETRIEVE_ALL_VEHICULE, ex);
            }
        }

        public async Task<WeaponResponse?> GetSpecificWeaponAsync(Guid weaponId)
        {
            try
            {
                Weapon? weapon = await _context.Weapon.SingleOrDefaultAsync(s => s.WeaponId == weaponId);
                return weapon != null ? _mapper.Map<WeaponResponse>(weapon) : null;
            }
            catch (DbException ex)
            {
                _logger.LogError(ex, ConstUtils.ERROR_LOG_WEAPON);
                throw new BrokenArrowException(ConstUtils.UNABLE_TO_RETRIEVE_SPECIFIC_VEHICULE, ex);
            }
        }
    }
}
