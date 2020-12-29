using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class VouchersController : ControllerBase
    {
        private readonly TGDDContext _context;

        public VouchersController(TGDDContext context)
        {
            _context = context;
        }

        // GET: api/Vouchers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voucher>>> GetVouchers()
        {
            var voucherGetAll = new VoucherGetAll();

            return await voucherGetAll.Excute();
        }

        // GET: api/Vouchers/5
        [HttpGet("{voucherId}")]
        public async Task<ActionResult<Voucher>> GetVoucher(long voucherId)
        {
            var voucherGetById = new VoucherGetById { VoucherId = voucherId };
            return await voucherGetById.Excute();
        }

        [HttpGet("Customer/{CustomerId}")]
        public async Task<ActionResult<List<Voucher>>> GetVoucherByCustomer(long CustomerId)
        {
            //var voucherGetById = new VoucherGetById { VoucherId = voucherId };
            //return await voucherGetById.Excute();

            VoucherGetByCustomer voucherGetByCustomer = new VoucherGetByCustomer { CustomerId = CustomerId };

            return await voucherGetByCustomer.Excute();
        }


        // PUT: api/Vouchers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<IActionResult> PutVoucher(VoucherDTO voucherDTO)
        {
            VoucherUpdate voucherUpdate = new VoucherUpdate { voucherDTO = voucherDTO };
            return await voucherUpdate.Excute();
        }

        // POST: api/Vouchers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Voucher>> PostVoucher(VoucherDTO voucher)
        {
            VoucherCreate voucherCreate = new VoucherCreate();

            return await voucherCreate.Excute();
        }

        //[HttpPost("UseVoucher")]
        //public async Task<ActionResult<Voucher>> UserVoucher(UserVoucherDTO voucherDTO)
        //{
        //    VoucherUse voucherUse = new VoucherUse { UserVoucherDTO = voucherDTO };

        //    return await voucherUse.Excute()
        //}

        // DELETE: api/Vouchers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Voucher>> DeleteVoucher(long id)
        {
            var voucherDelete = new VoucherDelete { VoucherId = id };

            return await voucherDelete.Excute();
        }

        private bool VoucherExists(long id)
        {
            return _context.Vouchers.Any(e => e.Id == id);
        }
    }
}
