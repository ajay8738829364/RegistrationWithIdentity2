using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Registration_Login_Identity.Models
{
    public class SendEmail : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            MailMessage mailMessage = new MailMessage();
                
                    mailMessage.From = new MailAddress("1996ajaypatel993@gmail.com");
                    mailMessage.Subject = subject;
                    mailMessage.Body = email + htmlMessage;
                    mailMessage.IsBodyHtml = true;
                    mailMessage.To.Add(new MailAddress(email));
                   SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
           
                    System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                    NetworkCred.UserName = "1996ajaypatel993@gmail.com";
                    NetworkCred.Password = "ajayrekha";
            smtp.EnableSsl = true;
             smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
                    

            try
            {

                await smtp.SendMailAsync(mailMessage);


                
            }
            catch(Exception e)
            {
                var sms=e.Message;
            }
        }
    }
}
