﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using WebAPI.ActionModels.CustomersMGT.CustomersVerifyEmail;
using WebAPI.IServices;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class MailService : IMailService
    {
        public string GetMailBody(Customer oCustomer)
        {
            //string url = Global.DomainName + "customers/ConfirmMail/" + oCustomer.UserName+"/"+oCustomer.Password;

            string url = "https://shop-cnweb.herokuapp.com/verify/" + oCustomer.UserName +"/"+ oCustomer.Password;

            return string.Format(@"<div style='text-align:center;'>
                                       <h1>Welcome to our Web Site</h1>
                                       <h3>Click below button for verify your Email Id</h3>
                                       <form method='Get' action='{0}' style = 'display : inline;' >
                                             <button type = 'submit' style='display : block;
                                                                                text-align : center;
                                                                                font-weight : bold;
                                                                                background-color : #008CBA;
                                                                                font-size : 16px;
                                                                                border-radius : 10px;
                                                                                color : #ffffff;
                                                                                cursor : pointer;
                                                                                width : 200px;
                                                                                padding: 10px;'>
                                                    Confirm Mail
                                            </button>
                                      </form>
                                  </div>", url); 
            
        }

        public string GetMailBodyForgetPassword(string token)
        { 
            string url = "https://shop-cnweb.herokuapp.com/forget_password/" + token;
            return string.Format(@"<div style='text-align:center;'>
                                       <h1>Welcome to our Web Site</h1>
                                       <h3>Click below button for reset password</h3>
                                       <form method='Get' action='{0}' style = 'display : inline;' >
                                             <button type = 'submit' style='display : block;
                                                                                text-align : center;
                                                                                font-weight : bold;
                                                                                background-color : #008CBA;
                                                                                font-size : 16px;
                                                                                border-radius : 10px;
                                                                                color : #ffffff;
                                                                                cursor : pointer;
                                                                                width : 200px;
                                                                                padding: 10px;'>
                                                    Reset Pasword
                                            </button>
                                      </form>
                                  </div>", url);

        } 
        public async Task<string> SendMail(MailClass oMailClass)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(oMailClass.FromMailId);
                    oMailClass.ToMailIds.ForEach(x =>
                    {
                        mail.To.Add(x);
                    });
                    mail.Subject = oMailClass.Subject;
                    mail.Body = oMailClass.Body;
                    mail.IsBodyHtml = oMailClass.isBodyHtml;

                    oMailClass.Attachments.ForEach(x =>
                    {
                        mail.Attachments.Add(new Attachment(x));
                    });

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new System.Net.NetworkCredential(oMailClass.FromMailId, oMailClass.FromMailIdPassword);
                        smtp.EnableSsl = true;
                        await smtp.SendMailAsync(mail);
                        return Message.MailSent;
                    };
                }
            }
            catch (Exception ex)
            {
                throw(ex);
            }
        }
    }
}
