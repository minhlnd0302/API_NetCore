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
    public class TopProductsController : ControllerBase
    {
        private readonly TGDDContext _context;

        public TopProductsController(TGDDContext context)
        {
            _context = context;
        }

        // GET: api/TopProducts
        [Authorize(Roles = "0")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TopProduct>>> GetTopProducts()
        {
            List<long> productId = await _context.Products.OrderByDescending(p => p.BuyingTimes).Select(p => p.Id).Take(10).ToListAsync();

            List<TopProduct> topProducts = await _context.TopProducts.ToListAsync();

            int tmp = 0;
            foreach(TopProduct topProduct in topProducts)
            {
                topProduct.ProductId = productId[tmp];
                _context.Entry(topProduct).State = EntityState.Modified; 
                tmp++; 
            }

            await _context.SaveChangesAsync();

            return await _context.TopProducts.Include(top=>top.Product).ThenInclude(p=>p.Images).ToListAsync();
        }

        // GET: api/TopProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TopProduct>> GetTopProduct(int id)
        {
            var topProduct = await _context.TopProducts.FindAsync(id);

            if (topProduct == null)
            {
                return NotFound();
            }

            return topProduct;
        }

        // PUT: api/TopProducts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTopProduct(int id, TopProduct topProduct)
        {
            if (id != topProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(topProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TopProductExists(id))
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

        // POST: api/TopProducts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TopProduct>> PostTopProduct(TopProduct topProduct)
        {
            _context.TopProducts.Add(topProduct);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TopProductExists(topProduct.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTopProduct", new { id = topProduct.Id }, topProduct);
        }

        // DELETE: api/TopProducts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TopProduct>> DeleteTopProduct(int id)
        {
            var topProduct = await _context.TopProducts.FindAsync(id);
            if (topProduct == null)
            {
                return NotFound();
            }

            _context.TopProducts.Remove(topProduct);
            await _context.SaveChangesAsync();

            return topProduct;
        }

        private bool TopProductExists(int id)
        {
            return _context.TopProducts.Any(e => e.Id == id);
        }
    }
}
