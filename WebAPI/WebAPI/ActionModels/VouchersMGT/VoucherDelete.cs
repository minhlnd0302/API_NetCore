﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ActionModels.VouchersMGT
{
    public class VoucherDelete : ControllerBase
    {
        public long VoucherId { get; set; }
        public async Task<ActionResult<Voucher>> Excute()
        {
            var _context = new TGDDContext();

            var voucher = await _context.Vouchers.FindAsync(VoucherId);
            if (voucher == null)
            {
                return NotFound();
            }

            _context.Vouchers.Remove(voucher);
            await _context.SaveChangesAsync();

            return voucher;
        }
    }
}
