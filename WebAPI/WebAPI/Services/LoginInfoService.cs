using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.ActionModels.CustomersMGT.CustomersVerifyEmail;
using WebAPI.IServices;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class LoginInfoService : ILoginInfoService
    {
        Customer _oCustomer = new Customer();

        Customer _oCustomerInfo = new Customer();
        public async Task<string> ConfirmMail(string username)
        {
            try
             {
                if (string.IsNullOrEmpty(username)) return "Invalid Usename";

                var tmp = new Customer
                {
                    UserName = username
                };

                Customer customer = await this.CheckRecordExistence(tmp);
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            return "ok";
        }

        public async Task<Customer> SignUp(Customer oCustomer)
        {
            var _context = new TGDDContext();


            _oCustomer = new Customer();

            try
            {
                Customer customer = await this.CheckRecordExistence(oCustomer);
                if (customer != null)
                {
                    var newCustomerId = _context.Customers.Max(p => p.Id) + 1;
                    oCustomer.Id = newCustomerId;

                    _context.Customers.Add(customer);  
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return oCustomer;
        }

        private async Task<Customer> CheckRecordExistence(Customer oCustomer)
        {
            //LoginInfo loginInfo = new LoginInfo();

            Customer customer = new Customer();
            if (string.IsNullOrEmpty(oCustomer.UserName))
            {
                //loginInfo = await this.GetLoginUser(customers.UserName);
                customer = await this.GetLoginUser(oCustomer.UserName);
                //if (customer != null)
                //{
                //    if ((bool)!customer.Verified)
                //    {

                //    }
                //}

            }
            return customer;
        }

        public async Task<Customer> GetLoginUser(string UserName)
        {
            //_oLoginInfo = new LoginInfo();

            var _context = new TGDDContext();

            var customers = new Customer();

            customers = await _context.Customers.FindAsync(UserName);

            //if (customers == null)
            //{
            //    return new NotFoundResult();
            //}

            return customers;
        }
    }
}
