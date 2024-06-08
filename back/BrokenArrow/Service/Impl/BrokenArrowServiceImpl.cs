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

        public async Task<IEnumerable<BrokenArrows>> retrieveAllBrokenArrows()
        {
            try
            {
                var brokensArrows = await _context.BrokenArrows.ToListAsync();
                return brokensArrows.Count != 0 ? brokensArrows : Enumerable.Empty<BrokenArrows>();
            }
            catch (DbException ex)
            {
                throw new BrokenArrowException(BrokenArrowUtils.UNABLE_TO_RETRIEVE_BA, ex);
            }
        }

        // to be modified after with all other service

        public async Task<IEnumerable<BrokenArrows>> retrieveBrokenArrowsByVehicule(Guid vehiculeId)
        {
            try
            {
                var brokensArrows = await _context.BrokenArrows.Where(b => b.VehiculeId == vehiculeId).ToListAsync();
                return brokensArrows.Count != 0 ? brokensArrows : Enumerable.Empty<BrokenArrows>();
            }
            catch (DbException ex)
            {
                throw new BrokenArrowException(BrokenArrowUtils.UNABLE_TO_RETRIEVE_BA, ex);
            }
        }

        // to be modified after with all other service

        public async Task<IEnumerable<BrokenArrows>> retrieveBrokenArrowsByWeapon(Guid weaponId)
        {
            try
            {
                var brokensArrows = await _context.BrokenArrows.Where(b => b.WeaponId == weaponId).ToListAsync();
                return brokensArrows.Count != 0 ? brokensArrows : Enumerable.Empty<BrokenArrows>();
            }
            catch (DbException ex)
            {
                throw new BrokenArrowException(BrokenArrowUtils.UNABLE_TO_RETRIEVE_BA, ex);
            }
        }

        public async Task<IEnumerable<BrokenArrows>> retrieveBrokenArrowsByYears(int year)
        {
            return await _context.BrokenArrows.Where(b => b.DisasterDate.Year == year).ToListAsync();
        }

        public async Task<BrokenArrows> retrieveSpecificBrokenArrow(Guid brokenArrowId)
        {
            return await _context.BrokenArrows.SingleOrDefaultAsync(b => b.BrokenArrowId == brokenArrowId);
        }
    }
}
