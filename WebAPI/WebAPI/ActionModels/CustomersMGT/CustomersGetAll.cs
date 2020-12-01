using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ActionModels.CustomersMGT
{
    public class CustomersGetAll
    {
        public async Task<ActionResult<IEnumerable<Customer>>> Excute()
        {
            var _context = new TGDDContext();

            return await _context.Customers.ToListAsync();
        }
    }
}
