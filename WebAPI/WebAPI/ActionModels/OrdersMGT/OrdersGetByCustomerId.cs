using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ActionModels.OrdersMGT
{
    public class OrdersGetByCustomerId : ControllerBase
    {
        public long CustomerId { get; set; }
        public async Task<ActionResult<IEnumerable<Order>>> Excute()
        {
            var _context = new TGDDContext();

            List<Order> orders = await _context.Orders.Where(order => order.CustomerId == CustomerId).Include(order=> order.Customer)
                                                                                            .Include(order => order.OrderDetails).ThenInclude(orderDetail=> orderDetail.Product)
                                                                                            .Include(order=>order.Status)
                                                                                            .ToListAsync();

            if (orders.Count < 1)
            {
                return NotFound("Không tìm thấy đơn hàng !");
            }
            return orders;
        }
    }
}
