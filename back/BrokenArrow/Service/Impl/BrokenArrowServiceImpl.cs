using BrokenArrow.Data;
using BrokenArrow.Exceptions;
using BrokenArrow.Models.Entities;
using BrokenArrow.Utils;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace BrokenArrow.Service.Impl
{
    public class BrokenArrowServiceImpl(BrokenArrowContext context) : IBrokenArrowService
    {
        private readonly BrokenArrowContext _context = context;

        public async Task<IEnumerable<BrokenArrows>> RetrieveAllBrokenArrows()
        {
            try
            {
                var brokenArrows = await _context.BrokenArrows.ToListAsync();
                return brokenArrows.Count != 0 ? brokenArrows : Enumerable.Empty<BrokenArrows>();
            }
            catch (DbException ex)
            {
                throw new BrokenArrowException(ConstUtils.UNABLE_TO_RETRIEVE_ALL_BA, ex);
            }
        }

        public async Task<IEnumerable<BrokenArrows>> RetrieveBrokenArrowsByVehicule(Guid vehiculeId)
        {
            try
            {
                var brokenArrows = await _context.BrokenArrows.Where(b => b.VehiculeId == vehiculeId).ToListAsync();
                return brokenArrows.Count != 0 ? brokenArrows : Enumerable.Empty<BrokenArrows>();
            }
            catch (DbException ex)
            {
                throw new BrokenArrowException(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_VEHICULE, ex);
            }
        }

        public async Task<IEnumerable<BrokenArrows>> RetrieveBrokenArrowsByWeapon(Guid weaponId)
        {
            try
            {
                var brokenArrows = await _context.BrokenArrows.Where(b => b.WeaponId == weaponId).ToListAsync();
                return brokenArrows.Count != 0 ? brokenArrows : Enumerable.Empty<BrokenArrows>();
            }
            catch (DbException ex)
            {
                throw new BrokenArrowException(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_WEAPON, ex);
            }
        }

        public async Task<IEnumerable<BrokenArrows>> RetrieveBrokenArrowsByYears(int year)
        {
            try
            {
                var brokenArrows = await _context.BrokenArrows.Where(b => b.DisasterDate.Year == year).ToListAsync();
                return brokenArrows.Count != 0 ? brokenArrows : Enumerable.Empty<BrokenArrows>();
            }
            catch (DbException ex)
            {
                throw new BrokenArrowException(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_YEAR, ex);
            }

        }

        public async Task<BrokenArrows?> RetrieveSpecificBrokenArrow(Guid brokenArrowId)
        {
            try
            {
                var brokenArrow = await _context.BrokenArrows.SingleOrDefaultAsync(b => b.BrokenArrowId == brokenArrowId);
                return brokenArrow;
            }
            catch (DbException ex)
            {
                throw new BrokenArrowException(ConstUtils.UNABLE_TO_RETRIEVE_SINGLE_BA, ex);
            }
        }
    }
}
