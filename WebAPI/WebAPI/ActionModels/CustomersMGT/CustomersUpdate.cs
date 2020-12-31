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

            Customer customer = await _context.Customers.FindAsync(Id);

            {
                customer.Lastname = this.Customer.Lastname;
                customer.Firstname = this.Customer.Firstname;
                customer.Address = this.Customer.Address;
                customer.Phone = this.Customer.Phone;
                customer.Gender = this.Customer.Gender;
            }

             

            _context.Entry(customer).State = EntityState.Modified;

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
            return NoContent();
        }
    }
}
