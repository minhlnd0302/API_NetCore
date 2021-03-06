﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.ActionModels.ProductsMGT;
using WebAPI.DTOModels;
using WebAPI.Models;
using WebAPI.Utils;

namespace WebAPI.ActionModels.OrdersMGT
{
    public class OrdersUpdateStatus : ControllerBase
    {
        public long OrderId { get; set; }
        public long StatusId { get; set; }
        public async Task<IActionResult> Excute()
        {
            var _context = new TGDDContext();
            var order = new Order();


            order = await _context.Orders.Include(o => o.OrderDetails).Where(order => order.Id == OrderId).FirstOrDefaultAsync();
            order.StatusId = StatusId;

            // update stock , buying time
            if (this.StatusId == 4)
            { 
                ProductsAutoUpdate productsAutoUpdate = new ProductsAutoUpdate(); 
                List<OrderDetail> orderDetails = order.OrderDetails.ToList(); 
                foreach (OrderDetail orderDetail in orderDetails) 
                {
                    Product product = await _context.Products.FindAsync(orderDetail.ProductId);
                    product.BuyingTimes -= orderDetail.Quantity;
                    product.Stock += orderDetail.Quantity;

                    _context.Entry(product).State = EntityState.Modified;
                } 
                await _context.SaveChangesAsync();  
            }

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

            return Ok("Chuyển trạng thái thành công !");
        }
    }
}
