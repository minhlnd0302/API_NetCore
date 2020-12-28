//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using WebAPI.Controllers;

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
using WebAPI.Controllers;
using WebAPI.Models;
using WebAPI.Utils;

namespace WebAPI.Models
{
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        //public IActionResult Excute()
        //{
        //    Customer login = new Customer();

        //    login.UserName = username;
        //    login.Password = password;

        //    IActionResult response = new UnauthorizedResult();

        //    var user = SecurityUtils.AuthenticateCustomer(login);

        //    if (user != null)
        //    {
        //        var tokenStr = SecurityUtils.GenerateJSONWebToken(user);
        //        response = new OkObjectResult(new { token = tokenStr, user = user });
        //    }
        //    else
        //    {
        //        //return StatusCode(403);
        //        return new StatusCodeResult(403);
        //    }

        //    return response;

        //}

    }
}
