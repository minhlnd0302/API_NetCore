using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ActionModels.CustomersMGT.CustomersVerifyEmail
{
    public class MailClass
    {
        public string FromMailId { get; set; } = "api.netcore@gmail.com";

        public string FromMailIdPassword { get; set; } = "123123123minh";
        public List<string> ToMailIds { get; set; } = new List<string>();

        public string Subject { get; set; } = "";

        public string Body { get; set; } = "";
        public bool isBodyHtml { get; set; } = true;

        public List<string> Attachments { get; set; } = new List<string>();
    }
}
