using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ActionModels.OrdersMGT
{
    public class OrdersGetAll
    {
        public async Task<ActionResult<IEnumerable<Order>>> Excute()
        {
            var _context = new TGDDContext();
            return await _context.Orders.ToListAsync();
        }
    }
}
