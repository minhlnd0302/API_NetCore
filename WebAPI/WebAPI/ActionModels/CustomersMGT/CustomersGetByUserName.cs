using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ActionModels.CustomersMGT
{
    public class CustomersGetByUserName : ControllerBase
    {
        public string Username { get; set; }
        public async Task<ActionResult<Customer>> Excute()
        {
            var _context = new TGDDContext();
            Customer customer =  _context.Customers.FirstOrDefault(c=>c.UserName == Username);

            if (customer == null)
            {
                return NotFound();
            } 
            return customer;
        }
    }
}
