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
    public class WeaponServiceImpl(BrokenArrowContext context, Mapper mapper, ILogger<WeaponServiceImpl> logger) : IWeaponService
    {
        private readonly BrokenArrowContext _context = context;
        private readonly Mapper _mapper = mapper;
        private readonly ILogger<WeaponServiceImpl> _logger = logger;
        public async Task<IEnumerable<WeaponResponse>> GetWeaponAsync()
        {
            try
            {
                List<Weapon> weapons = await _context.Weapons
                    .Include(s => s.BrokenArrows).ToListAsync();
                return weapons != null && weapons.Any() ? _mapper.Map<IEnumerable<WeaponResponse>>(weapons) : [];
            }
            catch (DbException ex)
            {
                _logger.LogError(ex, ConstUtils.ERROR_LOG_WEAPON);
                throw new BrokenArrowException(ConstUtils.UNABLE_TO_RETRIEVE_ALL_VEHICULE, ex);
            }
        }

        public async Task<WeaponResponse?> GetSingleWeaponAsync(Guid weaponId)
        {
            try
            {
                Weapon? weapon = await _context.Weapons.SingleOrDefaultAsync(s => s.WeaponId == weaponId);
                return weapon != null ? _mapper.Map<WeaponResponse>(weapon) : null;
            }
            catch (DbException ex)
            {
                _logger.LogError(ex, ConstUtils.ERROR_LOG_WEAPON);
                throw new BrokenArrowException(ConstUtils.UNABLE_TO_RETRIEVE_SPECIFIC_VEHICULE, ex);
            }
        }

        public async Task<IEnumerable<WeaponResponse?>> GetBrokenArrowsByWeaponAsync(AvailableWeapon availableWeapon)
        {
            try
            {
                string? weaponName = System.Enum.GetName(typeof(AvailableWeapon), value: availableWeapon);
                if (weaponName != null)
                {
                    List<Weapon> weapons = await _context.Weapons.Where(w => w.Name != null && w.Name.ToLower() == weaponName.ToLower())
                        .Include(w => w.BrokenArrows)
                        .ToListAsync();
                    return weapons != null ? _mapper.Map<IEnumerable<WeaponResponse>>(weapons) : [];
                }
                else
                {
                    return [];
                }
            }
            catch (DbException ex)
            {
                _logger.LogError(ex, ConstUtils.ERROR_LOG_BA);
                throw new BrokenArrowException(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_WEAPON, ex);
            }
        }
    }
}
