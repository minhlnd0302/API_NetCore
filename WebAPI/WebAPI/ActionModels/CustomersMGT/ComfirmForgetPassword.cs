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
    public class ComfirmForgetPassword : ControllerBase
    {
        private string Username { get; set; }
        private string Password { get; set; }

        public ComfirmForgetPassword(string username,string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public async Task<ActionResult<Customer>> Excute()
        {
            var _context = new TGDDContext();
            Customer customer = _context.Customers.FirstOrDefault(customer => customer.UserName == Username);

            if (customer == null)
            {
                return BadRequest();
            }
            else
            {
                customer.Password = SecurityUtils.CreateMD5(Password);

                _context.Entry(customer).State = EntityState.Modified;

            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                bool customerExist = _context.Customers.Any(c => c.Id == customer.Id);
                if (!customerExist)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }
    }
}
