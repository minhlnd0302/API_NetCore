using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOModels;
using WebAPI.Models;
using WebAPI.Utils;

namespace WebAPI.ActionModels.OrdersMGT
{
    public class OrdersCreate : ControllerBase
    {
        public OrderDTO OrderDTO { get; set; }
        public async Task<ActionResult<Order>> Excute()
        {
            AssigndataUtils AssigndataUtils = new AssigndataUtils();

            var _context = new TGDDContext();
            var order = new Order();
            order = AssigndataUtils.AssignOrder(OrderDTO, 0);

            _context.Orders.Add(order);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                bool orderExist = _context.Orders.Any(o => o.Id == order.Id); 
                if (orderExist)
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrders", new { id = order.Id }, order);
        }
    }
}
