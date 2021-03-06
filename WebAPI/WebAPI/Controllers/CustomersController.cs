﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.ActionModels.CustomersMGT;
using WebAPI.Models;

using WebAPI.ActionModels.CustomersMGT.CustomersVerifyEmail;
using WebAPI.IServices;
using WebAPI.DTOModels;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    { 
        private IMailService _mailService;

       
        public CustomersController(IMailService mailService)
        {
            _mailService = mailService;
        }

        //https://minhlnd.azurewebsites.net/Customers/all
        // GET: Customers
        // get all customers
        [Authorize(Roles = "0")]
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            CustomersGetAll customerGetAll = new CustomersGetAll();
            return await customerGetAll.Excute();
        }


        //https://minhlnd.azurewebsites.net/Customers/1
        // GET: Customers/5
        // get info user from id
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerFromId(long id)
        { 
            CustomersGetById customersGetById = new CustomersGetById { Id = id };

            return await customersGetById.Excute();
        } 


        //https://minhlnd.azurewebsites.net/Customers?username=user1
        [HttpGet]
        public async Task<ActionResult<Customer>> GetCustomerFromUsername([FromQuery]string username)
        {
            CustomersGetByUserName customersGetByUserName = new CustomersGetByUserName { Username = username }; 

            return await customersGetByUserName.Excute();
        }


        // PUT: api/Customers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCustomers(long id,[FromBody] Customer customer)
        //{
        //    //if (id != customer.Id)
        //    //{
        //    //    return BadRequest();
        //    //}

        //    customer.Id = id;

        //    _context.Entry(customer).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CustomersExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

         
        // create customer

        [HttpPost("add")]
        public async Task<ActionResult<Customer>> PostCustomers(Customer customer)
        {
           var customerCreate = new CustomersCreate (_mailService,customer);

           return await customerCreate.Excute();
        }


        [Authorize]
        [HttpPut("ChangePassword")]
        public async Task<ActionResult<Customer>> ChangerPassword(ChangePasswordDTO changePasswordDTO)
        {
            CustomersChangePassword customersChangePassword = new CustomersChangePassword
            {
                CustomerId = changePasswordDTO.CustomerId, 
                NewPassword = changePasswordDTO.NewPassword,
            }; 
            return await customersChangePassword.Excute();
        }

        [AllowAnonymous]
        [HttpGet("ConfirmMail/{username}/{pw}")]
        public async Task<IActionResult> ConfirmMail(string username, string pw)
        {
            VerifyEmail verifyEmail = new VerifyEmail { 
                Username = username,
                Pw = pw,
            }; 
            return await verifyEmail.Excute();
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(Customer customer)
        {
            CustomersUpdate customersUpdate = new CustomersUpdate { Customer = customer, Id = customer.Id };
            return await customersUpdate.Excute(); 
        }

        //[Authorize(Roles = "3")] 
        [AllowAnonymous]
        [HttpGet("ForgotPassword/{username}")]
        public async Task<ActionResult> ForgotPassword(string username)
        {
            ForgetPassword forgetPassword = new ForgetPassword (_mailService,username); 
            return await forgetPassword.Excute(); 
        }

        [Authorize(Roles = "3")] 
        [HttpPut("ConfirmForgotPassword")]
        public async Task<ActionResult<Customer>> ConfirmForgotPassword([FromForm]string newpassword)
        {
            var indentity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = indentity.Claims.ToList(); 
            var username = claim[0].Value;

            ComfirmForgetPassword comfirmForgetPassword = new ComfirmForgetPassword(username, newpassword);
            return await comfirmForgetPassword.Excute();
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomers(long id)
        {
            var _context = new TGDDContext();
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        //private bool CustomersExists(long id)
        //{
        //    return _context.Customers.Any(e => e.Id == id);
        //} 
    }
}
