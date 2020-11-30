using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly TGDDContext _context;

        public BrandsController(TGDDContext context)
        {
            _context = context;
        } 

        // GET: api/Brands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
        { 
            List<Brand> tmp = await _context.Brands.ToListAsync();


            return tmp;
        }

        // GET: api/Brands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetBrand(long id)
        {
            var brand = await _context.Brands.FindAsync(id);

            if (brand == null)
            {
                return NotFound();
            }

            return brand;
        }

        // PUT: api/Brands/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrands(long id, Brand brands)
        {
            if (id != brands.Id)
            {
                return BadRequest();
            }

            _context.Entry(brands).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandsExists(id))
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

        // POST: api/Brands
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Brand>> PostBrands(Brand brand)
        {
            _context.Brands.Add(brand);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BrandsExists(brand.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBrands", new { id = brand.Id }, brand);
        }

        // DELETE: api/Brands/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Brand>> DeleteBrands(long id)
        {
            var brands = await _context.Brands.FindAsync(id);
            if (brands == null)
            {
                return NotFound();
            }

            _context.Brands.Remove(brands);
            await _context.SaveChangesAsync();

            return brands;
        }

        private bool BrandsExists(long id)
        {
            return _context.Brands.Any(e => e.Id == id);
        }
    }
}
