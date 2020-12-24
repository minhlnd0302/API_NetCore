using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.ActionModels.CustomersMGT.CustomersVerifyEmail;
using WebAPI.IServices;
using WebAPI.Models;

namespace WebAPI.ActionModels.CustomersMGT
{
    public class VerifyEmail : ControllerBase
    {
        public string Username { get; set; }
        public string Pw { get; set; } 
        public async Task<IActionResult> Excute()
        {
            var _context = new TGDDContext();

            Customer customer = _context.Customers.Where(customer => customer.UserName == Username).FirstOrDefault();

            if(customer==null)
            {
                return BadRequest("Không tìm thấy tài khoản!");
            }

            if (customer.Password == Pw)
            {
                customer.Verified = true;

                _context.Entry(customer).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();  
                }
                catch
                {
                    return BadRequest();
                }
            }
            else return BadRequest();
            return Ok("Xác thực thành công !");
        } 
    }
}
