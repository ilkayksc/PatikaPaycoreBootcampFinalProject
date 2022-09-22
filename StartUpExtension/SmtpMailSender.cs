using System;
using System.Net.Mail;
using System.Configuration;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace PatikaPaycoreBootcampFinalProject.StartUpExtension
{
    public  class SmtpMailSender
    {
        IConfiguration configuration;
        public SmtpMailSender()
        {
            this.configuration = configuration;
        }
        public  void MailSender(string to,string message,string subject)
        {   
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(Startup.smtpConnstr.Host);
            mail.From = new MailAddress(Startup.smtpConnstr.Username);
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = message;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Port = Startup.smtpConnstr.Port;
            SmtpServer.Credentials = new System.Net.NetworkCredential(Startup.smtpConnstr.Username, Startup.smtpConnstr.Password);
            SmtpServer.EnableSsl = true;
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpServer.Send(mail);
        }
      
    }
}

