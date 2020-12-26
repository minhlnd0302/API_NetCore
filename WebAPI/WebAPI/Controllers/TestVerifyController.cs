using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.ActionModels.CustomersMGT.CustomersVerifyEmail;
using WebAPI.IServices;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestVerifyController : ControllerBase
    {
        private ILoginInfoService _loginInfoService;
        private IMailService _mailService;

        public TestVerifyController(ILoginInfoService loginInfoService, IMailService mailService)
        {
            _loginInfoService = loginInfoService;
            _mailService = mailService;
        }
         

        [AllowAnonymous]
        [HttpGet]
        
        public async Task<IActionResult> SignUp()
        {
            var customer = new Customer
            { 
                UserName = "user1",
                Password = "test"
            };
            


            var user = await _loginInfoService.SignUp(customer);

            MailClass mailClass = this.GetMailObject(customer);
            await _mailService.SendMail(mailClass);
            return Ok("adasd");
        }


        //[AllowAnonymous]
        //[HttpGet("ConfirmMail/{username}/{pw}")]
        //public async Task<IActionResult> ConfirmMail(string username, string pw)
        //{
        //    //string message = await _loginInfoService.ConfirmMail(username);
        //    return Ok("thanhf coong");
        //}

        public MailClass GetMailObject(Customer customer)
        {
            MailClass mailClass = new MailClass();
            //var tmp = new Customer
            //{
            //    UserName = "user1"
            //};

            mailClass.Subject = "test";
            mailClass.Body = _mailService.GetMailBody(customer);
            mailClass.ToMailIds = new List<string>()
            {
                //customer.Email,
                "leminh2344@gmail.com"
            };

            return mailClass;
        }

    }
}
