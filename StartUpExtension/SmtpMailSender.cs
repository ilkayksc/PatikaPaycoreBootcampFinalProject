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
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("ilkay.ksc2@gmail.com");
            mail.To.Add("ilkay.ksc2@gmail.com");
            mail.Subject = subject;
            mail.Body = message;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("ilkay.ksc2@gmail.com", "tpbsvxblugzdwlzn");
            SmtpServer.EnableSsl = true;
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpServer.Send(mail);
        }
      
    }
}

