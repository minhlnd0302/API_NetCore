﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ActionModels.VouchersMGT
{
    public class VoucherGetAll
    {
        public async Task<ActionResult<IEnumerable<Voucher>>> Excute()
        {
            var _context = new TGDDContext();
            return await _context.Vouchers.ToListAsync();
        }
    }
}
