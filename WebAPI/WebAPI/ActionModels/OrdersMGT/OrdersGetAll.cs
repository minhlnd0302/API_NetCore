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

            var orders = _context.Orders.Include(o => o.OrderDetails).ThenInclude(d => d.Product)
                                               .Include(o => o.Status)
                                               .Include(o => o.Customer)
                                               .Include(o => o.OrderDetails);
            
            return await orders.ToListAsync();
        }
    }
}
