using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ActionModels.CustomersMGT
{
    public class CustomersUpdate : ControllerBase
    {
        public long Id { get; set; }
        public Customer Customer { get; set; }
        public async Task<IActionResult> Excute()
        {
            //if (id != customer.Id)
            //{
            //    return BadRequest();
            //}

            var _context = new TGDDContext();
            this.Customer.Id = Id;

            _context.Entry(Customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                bool customerExist = _context.Customers.Any(c => c.Id == Customer.Id);
                if (!customerExist)
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
