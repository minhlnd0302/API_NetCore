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
            return await _context.TopCustomers.Include(c=>c.Customer).ToListAsync();
        } 
    }
}
