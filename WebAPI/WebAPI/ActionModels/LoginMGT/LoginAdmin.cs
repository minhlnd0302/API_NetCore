using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Controllers;
using WebAPI.Models;

namespace WebAPI.ActionModels.LoginMGT
{
    public class LoginAdmin : ControllerBase
    {
        public Login AdminLogin { get; set; }
        public IActionResult Excute()
        {
            //Admin login = new Admin();

            //login.UserName = admin.UserName;
            //login.Password = admin.Password;

            IActionResult response = Unauthorized();

            Admin admin = SecurityUtils.AuthenticateAdmin(AdminLogin);

            if (admin != null)
            {
                var tokenStr = SecurityUtils.GenerateJSONWebToken(admin);
                response = Ok(new { token = tokenStr, user = admin });
            }
            else
            {
                return StatusCode(403);
            }
            return response;
        }
    }
}
