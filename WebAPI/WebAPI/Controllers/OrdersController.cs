using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.ActionModels.OrdersMGT;
using WebAPI.DTOModels;
using WebAPI.Models;
using WebAPI.Utils;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        // GET: /Orders

        //https://minhlnd.azurewebsites.net/orders
        [Authorize(Roles = "0")]
        [HttpGet]
        //get all orders
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        { 
            var ordersGetAll = new OrdersGetAll();
            return await ordersGetAll.Excute();
        }

        //https://minhlnd.azurewebsites.net/orders/OrderId 
        [Authorize]
        [HttpGet("{OrderId}")]
        // get order from id order
        public async Task<ActionResult<Order>> GetOrder(long orderId)
        {
            var orderGetById = new OrdersGetById { OrderId = orderId };

            return await orderGetById.Excute();
        }

        //https://minhlnd.azurewebsites.net/orders/search?customerId=1
        [Authorize]
        [HttpGet("search")]
        // get order from id order
        public async Task<ActionResult<IEnumerable<Order>>> GetOrderByCustomerId([FromQuery] long customerId)
        {
            var orderGetByCustomerId = new OrdersGetByCustomerId { CustomerId = customerId };

            return await orderGetByCustomerId.Excute();
        }

        // PUT: api/Orders/5 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrders(long id, OrderDTO orderDTO)
        {
            var orderUpdate = new OrdersUpdate
            {
                Id = id,
                OrderDTO = orderDTO 
            };
            return await orderUpdate.Excute();
        }

        [HttpGet("status/{orderId}")]
        public async Task<IActionResult> UpdateStatus(long orderId, long statusId)
        {
            var orderUpdateStatus = new OrdersUpdateStatus
            {
                OrderId = orderId,
                StatusId = statusId
            };
            return await orderUpdateStatus.Excute();
        }

        // POST: api/Orders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrders(OrderDTO orderDTO)
        {
            var orderCreate = new OrdersCreate { OrderDTO = orderDTO };
            return await orderCreate.Excute();
        } 
    }
}
