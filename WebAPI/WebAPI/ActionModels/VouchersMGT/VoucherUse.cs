using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOModels;
using WebAPI.Models;

namespace WebAPI.ActionModels.VouchersMGT
{
    public class VoucherUse : ControllerBase
    {
        public UserVoucherDTO UserVoucherDTO { get; set; }
        public async Task<ActionResult<UseVoucher>> Excute()
        {
            var _context = new TGDDContext();

            Voucher voucher = _context.Vouchers.FirstOrDefault(voucher => voucher.Code == UserVoucherDTO.CodeVoucher);

            if (voucher == null)
            {
                return NotFound("Voucher khồn tồn tại");
            }
            else
            {

                DateTime date = DateTime.Now;

                if(date < voucher.StartDate && date > voucher.EndDate)
                {
                    return NotFound("Voucher đã hết hạn");
                }
                //UseVoucher useVoucher = _context.UseVouchers.FirstOrDefault(useVoucher.VoucherId == voucher.Id && useVoucher.CustomerId == UserVoucherDTO.CustomerId);

                UseVoucher useVoucher = _context.UseVouchers.Where(useVoucher => useVoucher.VoucherId == voucher.Id && useVoucher.CustomerId == UserVoucherDTO.CustomerId).FirstOrDefault();

                if (useVoucher == null)
                {
                    long newId = _context.UseVouchers.Max(useVoucher => useVoucher.Id) + 1;
                     
                    useVoucher = new UseVoucher
                    {
                        Id = newId,
                        CustomerId = UserVoucherDTO.CustomerId,
                        Used = true,
                        VoucherId = voucher.Id,
                        Voucher = voucher,
                    };

                    _context.UseVouchers.Add(useVoucher);

                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateException)
                    {
                        throw;
                    }
                }
                else
                {
                    return NotFound("Voucher đã được sử dụng !");
                }; 
            } 
            return Ok();
        }
    }
}
