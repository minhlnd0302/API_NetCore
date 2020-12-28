using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Controllers;
using WebAPI.Models;

namespace WebAPI.ActionModels.CustomersMGT
{ 
    public class CustomersChangePassword : ControllerBase
    {
        public long CustomerId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

        public async Task<ActionResult> Excute()
        {
            var _context = new TGDDContext();

            Customer customer = await _context.Customers.FindAsync(CustomerId);

            OldPassword = SecurityUtils.CreateMD5(OldPassword);

            if(OldPassword == customer.Password)
            {
                customer.Password = SecurityUtils.CreateMD5(NewPassword);
            }
            else
            {
                return BadRequest("Mật khẩu hiện tại không đúng !");
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            };

            return Ok("Đổi mật khẩu thành công !");

        }

    }
}
