using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class YearStatisticalsController : ControllerBase
    {
        private readonly TGDDContext _context;

        public YearStatisticalsController(TGDDContext context)
        {
            _context = context;
        }

        // GET: api/YearStatisticals
        [Authorize(Roles = "0")] 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YearStatistical>>> GetYearStatisticals()
        {
            return await _context.YearStatisticals.Include(yearStatistical=>yearStatistical.DayStatisticals)
                                                  .Include(yearStatistical=>yearStatistical.WeekStatisticals)
                                                  .Include(yearStatistical=>yearStatistical.MonthStatisticals) 
                                                  .ToListAsync();
        }

        // GET: api/YearStatisticals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YearStatistical>> GetYearStatistical(long id)
        {
            var yearStatistical = await _context.YearStatisticals.FindAsync(id);

            if (yearStatistical == null)
            {
                return NotFound();
            }

            return yearStatistical;
        }

        // PUT: api/YearStatisticals/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYearStatistical(long id, YearStatistical yearStatistical)
        {
            if (id != yearStatistical.Id)
            {
                return BadRequest();
            }

            _context.Entry(yearStatistical).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YearStatisticalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/YearStatisticals
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<YearStatistical>> PostYearStatistical(YearStatistical yearStatistical)
        {
            _context.YearStatisticals.Add(yearStatistical);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (YearStatisticalExists(yearStatistical.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetYearStatistical", new { id = yearStatistical.Id }, yearStatistical);
        }

        // DELETE: api/YearStatisticals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<YearStatistical>> DeleteYearStatistical(long id)
        {
            var yearStatistical = await _context.YearStatisticals.FindAsync(id);
            if (yearStatistical == null)
            {
                return NotFound();
            }

            _context.YearStatisticals.Remove(yearStatistical);
            await _context.SaveChangesAsync();

            return yearStatistical;
        }

        private bool YearStatisticalExists(long id)
        {
            return _context.YearStatisticals.Any(e => e.Id == id);
        }
    }
}
