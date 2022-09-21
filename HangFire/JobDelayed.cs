using System;
using System.Net.Mail;
using System.Text;
using PatikaPaycoreBootcampFinalProject.StartUpExtension;
namespace PatikaPaycoreBootcampFinalProject.HangFire
{
    public static class JobDelayed
    {
        public static void Run(string to,string message,string subject)
        {   
            var smtp = new SmtpMailSender();
            smtp.MailSender(to, message, subject);
          
        }
    }
}