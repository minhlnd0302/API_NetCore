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
    public class CirclesController : ControllerBase
    {
        private readonly TGDDContext _context;

        public CirclesController(TGDDContext context)
        {
            _context = context;
        }

        // GET: api/Circles
        //[Authorize(Roles = "0")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Circle>>> GetCircle()
        {

            List<OrderDetail> orderDetails = await _context.OrderDetails.Include(o=>o.Product).ToListAsync();

            List<Circle> circles = await _context.Circle.ToListAsync();

            var c = new int[4];

            foreach(OrderDetail orderDetail in orderDetails)
            {
                c[orderDetail.Product.CategoryId.Value-1] += orderDetail.Quantity.Value;
            }

            int tmp = 0;
            foreach(Circle circle in circles)
            {
                circle.SoldQuantity = c[tmp];
                _context.Entry(circle).State = EntityState.Modified;
                tmp++; 
            }

            await _context.SaveChangesAsync();




            return await _context.Circle.Include(c=>c.Category).ToListAsync();
        } 
    }
}
