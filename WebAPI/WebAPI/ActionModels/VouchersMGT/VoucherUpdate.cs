using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOModels;
using WebAPI.Models;
using WebAPI.Utils;

namespace WebAPI.ActionModels.VouchersMGT
{
    public class VoucherUpdate : ControllerBase
    {
        public VoucherDTO voucherDTO { get; set; }
        public async Task<IActionResult> Excute()
        {
            var _context = new TGDDContext();

            Voucher voucherUpdate = AssigndataUtils.AssignVoucher(voucherDTO, voucherDTO.Id);

            _context.Entry(voucherUpdate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                bool voucherExist = _context.Vouchers.Any(voucher => voucher.Id == voucherUpdate.Id);
                if (!voucherExist)
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
    }
}
