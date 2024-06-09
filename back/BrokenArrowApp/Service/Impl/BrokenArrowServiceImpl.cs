using BrokenArrowApp.Data;
using BrokenArrowApp.Exceptions;
using BrokenArrowApp.Models.Entities;
using BrokenArrowApp.Utils;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace BrokenArrowApp.Service.Impl
{
    public class BrokenArrowServiceImpl(BrokenArrowContext context) : IBrokenArrowService
    {
        private readonly BrokenArrowContext _context = context;

        public async Task<IEnumerable<BrokenArrow>> RetrieveAllBrokenArrows()
        {
            try
            {
                var brokenArrows = await _context.BrokenArrows.ToListAsync();
                return brokenArrows.Count != 0 ? brokenArrows : Enumerable.Empty<BrokenArrow>();
            }
            catch (DbException ex)
            {
                throw new BrokenArrowException(ConstUtils.UNABLE_TO_RETRIEVE_ALL_BA, ex);
            }
        }

        public async Task<IEnumerable<BrokenArrow>> RetrieveAllBrokenArrowsByCoordonate(Guid coordonate)
        {
            try
            {
                var brokenArrows = await _context.BrokenArrows.Where(b => b.CoordonateId == coordonate).ToListAsync();
                return brokenArrows.Count != 0 ? brokenArrows : Enumerable.Empty<BrokenArrow>();
            }
            catch (DbException ex)
            {
                throw new BrokenArrowException(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_COORDONATE, ex);
            }
        }

        public async Task<IEnumerable<BrokenArrow>> RetrieveBrokenArrowsByVehicule(Guid vehiculeId)
        {
            try
            {
                var brokenArrows = await _context.BrokenArrows.Where(b => b.VehiculeId == vehiculeId).ToListAsync();
                return brokenArrows.Count != 0 ? brokenArrows : Enumerable.Empty<BrokenArrow>();
            }
            catch (DbException ex)
            {
                throw new BrokenArrowException(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_VEHICULE, ex);
            }
        }

        public async Task<IEnumerable<BrokenArrow>> RetrieveBrokenArrowsByWeapon(Guid weaponId)
        {
            try
            {
                var brokenArrows = await _context.BrokenArrows.Where(b => b.WeaponId == weaponId).ToListAsync();
                return brokenArrows.Count != 0 ? brokenArrows : Enumerable.Empty<BrokenArrow>();
            }
            catch (DbException ex)
            {
                throw new BrokenArrowException(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_WEAPON, ex);
            }
        }

        public async Task<IEnumerable<BrokenArrow>> RetrieveBrokenArrowsByYears(int year)
        {
            try
            {
                var brokenArrows = await _context.BrokenArrows.Where(b => b.DisasterDate.Year == year).ToListAsync();
                return brokenArrows.Count != 0 ? brokenArrows : Enumerable.Empty<BrokenArrow>();
            }
            catch (DbException ex)
            {
                throw new BrokenArrowException(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_YEAR, ex);
            }

        }

        public async Task<BrokenArrow?> RetrieveSpecificBrokenArrow(Guid brokenArrowId)
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
