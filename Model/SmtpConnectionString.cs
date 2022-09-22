using System;
namespace PatikaPaycoreBootcampFinalProject.Model
{
    public class SmtpConnectionString
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public SmtpConnectionString()
        {
        }
    }
}

