using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.ActionModels.CustomersMGT.CustomersVerifyEmail;
using WebAPI.Controllers;
using WebAPI.IServices;
using WebAPI.Models;

namespace WebAPI.ActionModels.CustomersMGT
{
    public class ForgetPassword : ControllerBase
    {
        private IMailService _mailService;
        public string Username { get; set; }

        public ForgetPassword(IMailService mailService, string username)
        {
            _mailService = mailService;
            Username = username;
        }
        public async Task<ActionResult> Excute()
        {
            var _context = new TGDDContext();
            var forgotPassword = new ForgotPassword();

            Customer customer = await forgotPassword.FindAccount(Username);



            if (customer != null)
            {
                MailClass mailClass = GetMailObjectForgotPassword(customer);
                await _mailService.SendMail(mailClass);
                return Ok();
            }
            return BadRequest();
        }
        private MailClass  GetMailObjectForgotPassword(Customer Cus)
        {

            var forgotPassword = new ForgotPassword();
            MailClass mailClass = new MailClass();


            string token = forgotPassword.GenerateJSONWebTokenForgotPassword(Cus.UserName, Cus.Password);

            mailClass.Subject = "Hi, " + Cus.Lastname + " " + Cus.Firstname;
            mailClass.Body = _mailService.GetMailBodyForgetPassword(token);
            mailClass.ToMailIds = new List<string>()
            {
                 Cus.Email,
            };
            return mailClass;
        }
    }
}
