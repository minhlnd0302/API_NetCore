using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ActionModels.CustomersMGT
{
    public class CustomersCreate : ControllerBase
    {
        public Customer Customer { get; set; }
        public async Task<ActionResult<Customer>> Excute()
        {
            var _context = new TGDDContext();

            var newCustomerId = _context.Customers.Max(c => c.Id) + 1;
            Customer.Id = newCustomerId;

            _context.Customers.Add(Customer);
            try
            { 
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            { 
                bool customerExist = _context.Customers.Any(c => c.Id == Customer.Id);
                if (customerExist)
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            } 
            return CreatedAtAction("GetCustomers", new { id = Customer.Id }, Customer);
        }
    }
}
