using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ActionModels.CustomersMGT.CustomersVerifyEmail
{
    public static class Message
    {
        public static string Success = "Success";
        public static string ErrorFound = "Error Found";
        public static string UserAlreadyCreated = "User already created, please login.";
        public static string VerifyMail = "User already created, please verify your given Email Id.";
        public static string UnvalidUser = "Invalid user. Please create account";
        public static string MailSent = "Mail Sent";
        public static string UserCreatedVerifyEmail = "User created. Check Email. Click link and varify.";

    }
}
