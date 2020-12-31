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
        [Authorize(Roles = "0")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Circle>>> GetCircle()
        {
            return await _context.Circle.Include(c=>c.Category).ToListAsync();
        } 
    }
}
