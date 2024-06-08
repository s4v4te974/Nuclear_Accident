using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BrokenArrow.Data;
using BrokenArrow.Models.Entities;

namespace BrokenArrow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrokenArrowsController : ControllerBase
    {
        private readonly BrokenArrowContext _context;

        public BrokenArrowsController(BrokenArrowContext context)
        {
            _context = context;
        }

        // GET: api/BrokenArrows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrokenArrows>>> GetBrokenArrows()
        {
            return await _context.BrokenArrows.ToListAsync();
        }

        // GET: api/BrokenArrows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BrokenArrows>> GetBrokenArrows(Guid id)
        {
            var brokenArrows = await _context.BrokenArrows.FindAsync(id);

            if (brokenArrows == null)
            {
                return NotFound();
            }

            return brokenArrows;
        }


        // POST: api/BrokenArrows
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BrokenArrows>> PostBrokenArrows(BrokenArrows brokenArrows)
        {
            _context.BrokenArrows.Add(brokenArrows);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBrokenArrows", new { id = brokenArrows.BrokenArrowId }, brokenArrows);
        }

        // DELETE: api/BrokenArrows/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrokenArrows(Guid id)
        {
            var brokenArrows = await _context.BrokenArrows.FindAsync(id);
            if (brokenArrows == null)
            {
                return NotFound();
            }

            _context.BrokenArrows.Remove(brokenArrows);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BrokenArrowsExists(Guid id)
        {
            return _context.BrokenArrows.Any(e => e.BrokenArrowId == id);
        }
    }
}
