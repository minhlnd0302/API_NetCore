using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.ActionModels.CustomersMGT.CustomersVerifyEmail;
using WebAPI.Models;

namespace WebAPI.IServices
{
    public interface ILoginInfoService
    {
        Task<Customer> SignUp(Customer oCustomer);

        Task<string> ConfirmMail(string username);
    }
}
