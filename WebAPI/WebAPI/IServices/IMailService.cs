using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.ActionModels.CustomersMGT.CustomersVerifyEmail;
using WebAPI.Models;

namespace WebAPI.IServices
{
    public interface IMailService
    {
        Task<string> SendMail(MailClass oMailClass);

        string GetMailBody(Customer oCustomer);
    }
}
