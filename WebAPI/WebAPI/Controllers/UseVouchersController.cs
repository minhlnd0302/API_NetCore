using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.ActionModels.VouchersMGT;
using WebAPI.DTOModels;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UseVouchersController : ControllerBase
    {
        private readonly TGDDContext _context;

        public UseVouchersController(TGDDContext context)
        {
            _context = context;
        }

        // GET: api/UseVouchers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UseVoucher>>> GetUseVouchers()
        {
            return await _context.UseVouchers.ToListAsync();
        }

        // GET: api/UseVouchers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UseVoucher>> GetUseVoucher(long id)
        {
            var useVoucher = await _context.UseVouchers.FindAsync(id);

            if (useVoucher == null)
            {
                return NotFound();
            }

            return useVoucher;
        }

        // PUT: api/UseVouchers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUseVoucher(long id, UseVoucher useVoucher)
        {
            if (id != useVoucher.Id)
            {
                return BadRequest();
            }

            _context.Entry(useVoucher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UseVoucherExists(id))
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

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<UseVoucher>> PostUseVoucher(UserVoucherDTO voucherDTO)
        {
            VoucherUse voucherUse = new VoucherUse { UserVoucherDTO = voucherDTO };

            return await voucherUse.Excute();
        }

        // DELETE: api/UseVouchers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UseVoucher>> DeleteUseVoucher(long id)
        {
            var useVoucher = await _context.UseVouchers.FindAsync(id);
            if (useVoucher == null)
            {
                return NotFound();
            }

            _context.UseVouchers.Remove(useVoucher);
            await _context.SaveChangesAsync();

            return useVoucher;
        }

        private bool UseVoucherExists(long id)
        {
            return _context.UseVouchers.Any(e => e.Id == id);
        }
    }
}
