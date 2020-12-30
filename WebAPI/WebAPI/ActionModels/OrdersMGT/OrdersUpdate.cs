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
    public class OrdersUpdate : ControllerBase
    {
        public OrderDTO OrderDTO { get; set; }
        public long Id { get; set; }
        public async Task<IActionResult> Excute()
        {
            AssigndataUtils AssigndataUtils = new AssigndataUtils();

            var _context = new TGDDContext();
            var order = new Order();
            order = await AssigndataUtils.AssignOrder(OrderDTO, Id);

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                bool orderExist = _context.Orders.Any(o => o.Id == order.Id);
                if (!orderExist)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Cập nhật thành công !");
        }
    }
}
