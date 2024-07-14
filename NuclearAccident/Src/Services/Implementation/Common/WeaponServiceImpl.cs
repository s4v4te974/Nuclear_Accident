using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NuclearIncident.Src.Common.DbSet;
using NuclearIncident.Src.Common.Dtos;
using NuclearIncident.Src.Common.Enum;
using NuclearIncident.Src.Common.Exceptions;
using NuclearIncident.Src.Common.Utils;
using NuclearIncident.Src.Data;
using NuclearIncident.Src.Services.Interfaces.Common;
using System.Data.Common;

namespace NuclearIncident.Src.Services.Implementation.Common
{
    public class WeaponServiceImpl(NuclearBrokenArrowsContext context, IMapper mapper, ILogger<WeaponServiceImpl> logger) : IWeaponService
    {
        private readonly NuclearBrokenArrowsContext _context = context;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<WeaponServiceImpl> _logger = logger;
        public async Task<IEnumerable<WeaponResponse>> GetWeaponsAsync()
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
                throw new NuclearIncidentException(ConstUtils.UNABLE_TO_RETRIEVE_ALL_WEAPON, ex);
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
                throw new NuclearIncidentException(ConstUtils.UNABLE_TO_RETRIEVE_SPECIFIC_WEAPON, ex);
            }
        }

        public async Task<IEnumerable<WeaponResponse?>> GetBrokenArrowssByWeaponAsync(AvailableWeapon availableWeapon)
        {
            try
            {
                string? weaponName = Enum.GetName(typeof(AvailableWeapon), value: availableWeapon);
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
                throw new NuclearIncidentException(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_WEAPON, ex);
            }
        }
    }
}
