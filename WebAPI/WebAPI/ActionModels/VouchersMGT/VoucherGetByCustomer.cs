using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ActionModels.VouchersMGT
{
         
    public class VoucherGetByCustomer
    {
        public long CustomerId { get; set; }

        public async Task<ActionResult<List<Voucher>>> Excute()
        {
            var _context = new TGDDContext();

            List<Voucher> vouchers = await _context.Vouchers.ToListAsync();

            List<UseVoucher> userVouchers = await _context.UseVouchers.Where(u=>u.CustomerId == CustomerId).ToListAsync();

            List<Voucher> vouchersCanUse = new List<Voucher>(); 
             

            foreach(Voucher voucher in vouchers)
            {
                if (voucher.EndDate < DateTime.Now) continue;
                if(userVouchers.Count < 1)
                {
                    vouchersCanUse = vouchers;
                    break;
                }
                foreach(UseVoucher useVoucher in userVouchers)
                {
                    if(useVoucher.VoucherId == voucher.Id)
                    {
                        break; 
                    }
                    else
                    {
                        int l = userVouchers.Count() - 1;
                        if(useVoucher.VoucherId == userVouchers[l].VoucherId)
                        {
                            vouchersCanUse.Add(voucher);
                        }
                    }
                }
            }

            return vouchersCanUse; 
        }
    }
}
