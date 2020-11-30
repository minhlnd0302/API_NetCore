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
        public async Task<ActionResult<Customer>> PostCustomers(Customer customer)
        {
            var _context = new TGDDContext();
            _context.Customers.Add(customer);
            try
            {

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomersExists(customer.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomers", new { id = customer.Id }, customer);
        }
    }
}
