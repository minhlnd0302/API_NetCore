using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using WebAPI.Models;
using WebAPI.Utils;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        private readonly TGDDContext _context;

        public LoginController(IConfiguration config, TGDDContext context)
        {
            _config = config;
            _context = context;
            //AssigndataUtils._context = _context;
            SecurityUtils._context = _context;
            SecurityUtils._config = config;
        }

        [AllowAnonymous]
        [HttpPost("Customer")]
         
        public IActionResult LoginCustomer([FromBody] Login admin)
        {  
            //Customers login = new Customers();

            //login.UserName = admin.username;
            //login.Password = admin.password;

            //IActionResult response = Unauthorized();

            //var user = SecurityUtils.AuthenticateCustomer(login);

            //if (user != null)
            //{
            //    var tokenStr = SecurityUtils.GenerateJSONWebToken(user);
            //    response = Ok(new { token = tokenStr, user = user });
            //}
            //else
            //{
            //    return StatusCode(403);
            //}

            //return response;

            return admin.Excute();
        }


        [AllowAnonymous]
        [HttpPost("Admin")]
        public IActionResult LoginAdmin([FromBody] Login admin)
        {
            Admin login = new Admin();

            login.UserName = admin.username;
            login.Password = admin.password;

            IActionResult response = Unauthorized();

            var user = SecurityUtils.AuthenticateAdmin(login);

            if (user != null)
            {
                var tokenStr = SecurityUtils.GenerateJSONWebToken(user);
                response = Ok(new { token = tokenStr, user = user });
            }
            else
            {
                return StatusCode(403);
            }
            return response;
        }

        [HttpPost]
        public string WhoIAm()
        {
            var indentity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = indentity.Claims.ToList();

            var admin = claim[0].Value;
            return "Welcome to : " + admin;
        }

        [Authorize(Roles = "0")]
        [HttpGet("GetValue1")]
        public ActionResult<IEnumerable<string>> Get1()
        {

            var email = User.FindFirst("sub")?.Value;
            var username = User.FindFirst(JwtRegisteredClaimNames.Sub);
            //var s = WhoIAm();
            //bool tmp = SecurityUtils.isAdmin(_context, s);
            return new string[] { "1", "V2", "V3" };
        }

        [Authorize]
        [HttpGet("GetValue2")]
        public ActionResult<IEnumerable<string>> Get2()
        {
            //var s = WhoIAm();
            //bool tmp = SecurityUtils.isAdmin(_context, s);
            return new string[] { "2", "V2", "V3" };
        }
    }
}
