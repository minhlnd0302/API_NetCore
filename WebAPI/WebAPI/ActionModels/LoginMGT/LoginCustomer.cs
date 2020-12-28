using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Controllers;
using WebAPI.Models;

namespace WebAPI.ActionModels.LoginMGT
{
    public class LoginCustomer
    {
        public Login CustomerLogin { get; set; } 
        public IActionResult Excute()
        {
            //Customer login = new Customer();

            //login.UserName = CustomerLogin.UserName;
            //login.Password = CustomerLogin.Password;

            IActionResult response = new UnauthorizedResult();

            Customer customer = SecurityUtils.AuthenticateCustomer(CustomerLogin);

            if (customer != null)
            {
                var tokenStr = SecurityUtils.GenerateJSONWebToken(customer);
                response = new OkObjectResult(new { token = tokenStr, user = customer });
            }
            else
            {
                //return StatusCode(403);
                return new StatusCodeResult(403);
            }

            return response;

        }
    }
}
