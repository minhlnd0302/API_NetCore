using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ActionModels.CustomersMGT
{
    public class CustomersGetById : ControllerBase
    {
        public long Id { get; set; }
        public async Task<ActionResult<Customer>> Excute()
        {
            var _context = new TGDDContext();
            var customers = await _context.Customers.FindAsync(Id);

            if (customers == null)
            {
                return NotFound();
            }

            return customers;
        }
    }
}
