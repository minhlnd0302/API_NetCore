using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using WebAPI.ActionModels.CustomersMGT.CustomersVerifyEmail;
using WebAPI.Controllers;
using WebAPI.IServices;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.ActionModels.CustomersMGT
{
    public class CustomersCreate : ControllerBase
    {  
        public Customer Customer { get; set; }


        private IMailService _mailService; 
        public CustomersCreate(IMailService mailService, Customer customer)
        {
            _mailService = mailService;
            Customer = customer;
        }

        public async Task<ActionResult<Customer>> Excute()
        {
            var _context = new TGDDContext();

            var newCustomerId = _context.Customers.Max(c => c.Id) + 1;
            Customer.Id = newCustomerId;
            Customer.Password = SecurityUtils.CreateMD5(Customer.Password);

            _context.Customers.Add(Customer);
            try
            { 
                await _context.SaveChangesAsync();

                {
                    MailClass mailClass = GetMailObject(Customer);
                    await _mailService.SendMail(mailClass);
                }
            }
            catch (DbUpdateException)
            { 
                bool customerExist = _context.Customers.Any(c => c.Id == Customer.Id);
                if (customerExist)
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            } 
            return CreatedAtAction("GetCustomers", new { id = Customer.Id }, Customer);
        }
        private MailClass GetMailObject(Customer Cus)
        {
            MailClass mailClass = new MailClass();

            mailClass.Subject = "Hi, " + Cus.Lastname + " " + Cus.Firstname;
            mailClass.Body = _mailService.GetMailBody(Cus);
            mailClass.ToMailIds = new List<string>()
            {
                 Cus.Email,
            };
            return mailClass;
        }
    }
}
