using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TopCustomersController : ControllerBase
    {
        private readonly TGDDContext _context;

        public TopCustomersController(TGDDContext context)
        {
            _context = context;
        }

        // GET: api/TopCustomers
        [Authorize(Roles = "0")] 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TopCustomer>>> GetTopCustomers()
        {
            List<Order> orders = await _context.Orders.OrderByDescending(o => o.Date).Take(10).ToListAsync();
            //List<Order> orders = await _context.Orders.OrderBy(o => o.Date).Take(10).ToListAsync();

            List<TopCustomer> customers = await _context.TopCustomers.ToListAsync();

            int tmp = 0;
            foreach(TopCustomer topCustomer in customers)
            {
                topCustomer.CustomerId = orders[tmp].CustomerId;
                topCustomer.LastBuy = orders[tmp].Date;
                _context.Entry(topCustomer).State = EntityState.Modified;
                tmp++;
            }

            await _context.SaveChangesAsync();

            return await _context.TopCustomers.Include(c=>c.Customer).ToListAsync();
        } 
    }
}
