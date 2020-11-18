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
    [Route("api/[controller]")]
    [ApiController]
    public class DescriptionsController : ControllerBase
    {
        private readonly TGDDContext _context;

        public DescriptionsController(TGDDContext context)
        {
            _context = context;
        }

        // GET: api/Descriptions
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Description>>> GetDescriptions()
        {
            return await _context.Descriptions.ToListAsync();
        }

        // GET: api/Descriptions/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<Description>> GetDescriptions(long id)
        {
            var description = await _context.Descriptions.FindAsync(id);

            if (description == null)
            {
                return NotFound();
            }

            return description;
        }

        // PUT: api/Descriptions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "0")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDescriptions(long id, Description description)
        {
            if (id != description.Id)
            {
                return BadRequest();
            }

            _context.Entry(description).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DescriptionsExists(id))
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

        // POST: api/Descriptions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.


        [Authorize(Roles = "0")]
        [HttpPost]
        public async Task<ActionResult<Description>> PostDescriptions(Description description)
        {
            _context.Descriptions.Add(description);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DescriptionsExists(description.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDescriptions", new { id = description.Id }, description);
        }

        // DELETE: api/Descriptions/5
        [Authorize(Roles = "0")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Description>> DeleteDescriptions(long id)
        {
            var description = await _context.Descriptions.FindAsync(id);
            if (description == null)
            {
                return NotFound();
            }

            _context.Descriptions.Remove(description);
            await _context.SaveChangesAsync();

            return description;
        }

        private bool DescriptionsExists(long id)
        {
            return _context.Descriptions.Any(e => e.Id == id);
        }
    }
}
