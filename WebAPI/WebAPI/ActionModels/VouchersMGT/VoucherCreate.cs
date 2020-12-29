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
    public class VoucherCreate : ControllerBase
    {
        public VoucherDTO voucherDTO { get; set; }
        public async Task<ActionResult<Voucher>> Excute()
        {
            AssigndataUtils AssigndataUtils = new AssigndataUtils();

            Voucher newVoucher = AssigndataUtils.AssignVoucher(voucherDTO, 0);

            var _context = new TGDDContext();

            _context.Vouchers.Add(newVoucher);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                bool voucherExist = _context.Vouchers.Any(voucher => voucher.Id == newVoucher.Id);

                if (voucherExist)
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("GetVoucher", new { id = newVoucher.Id }, newVoucher);
        }
    }
}
