using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ActionModels.OrdersMGT
{
    public class OrdersGetById : ControllerBase
    {
        public long OrderId { get; set; }
        public async Task<ActionResult<Order>> Excute()
        {
            var _context = new TGDDContext();
            var order = await _context.Orders.FindAsync(OrderId);
            
            if (order == null)
            {
                return NotFound("Không tìm thấy đơn hàng !");
            }
            return order;
        }
    }
}
