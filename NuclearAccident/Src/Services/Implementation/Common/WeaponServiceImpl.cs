using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NuclearAccident.Src.Common.DbSet;
using NuclearAccident.Src.Common.Dtos;
using NuclearAccident.Src.Common.Enum;
using NuclearAccident.Src.Common.Exceptions;
using NuclearAccident.Src.Common.Utils;
using NuclearAccident.Src.Data;
using NuclearAccident.Src.Services.Interfaces.Common;
using System.Data.Common;

namespace NuclearAccident.Src.Services.Implementation.Common
{
    public class WeaponServiceImpl(NuclearAccidentContext context, IMapper mapper, ILogger<WeaponServiceImpl> logger) : IWeaponService
    {
        private readonly NuclearAccidentContext _context = context;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<WeaponServiceImpl> _logger = logger;
        public async Task<IEnumerable<WeaponResponse>> GetWeaponsAsync()
        {
            try
            {
                List<Weapon> weapons = await _context.Weapons
                    .Include(s => s.Accidents).ToListAsync();
                return weapons != null && weapons.Any() ? _mapper.Map<IEnumerable<WeaponResponse>>(weapons) : [];
            }
            catch (DbException ex)
            {
                _logger.LogError(ex, ConstUtils.ERROR_LOG_WEAPON);
                throw new NuclearInccidentException(ConstUtils.UNABLE_TO_RETRIEVE_ALL_WEAPON, ex);
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
                throw new NuclearInccidentException(ConstUtils.UNABLE_TO_RETRIEVE_SPECIFIC_WEAPON, ex);
            }
        }

        public async Task<IEnumerable<WeaponResponse?>> GetAccidentsByWeaponAsync(AvailableWeapon availableWeapon)
        {
            try
            {
                string? weaponName = Enum.GetName(typeof(AvailableWeapon), value: availableWeapon);
                if (weaponName != null)
                {
                    List<Weapon> weapons = await _context.Weapons.Where(w => w.Name != null && w.Name.ToLower() == weaponName.ToLower())
                        .Include(w => w.Accidents)
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
                throw new NuclearInccidentException(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_WEAPON, ex);
            }
        }
    }
}
