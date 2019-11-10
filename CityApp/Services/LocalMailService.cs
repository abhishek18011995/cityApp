using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CityApp.Services
{
    public class LocalMailService: ILocalMailService
    {
        private readonly IConfiguration Configuration;

        private string MailTo { get; } 
        private string MailFrom { get; }

        public LocalMailService(IConfiguration configuration)
        {
            Configuration = configuration;
            MailTo = Configuration["MailSettings:MailTo"];
            MailFrom = Configuration["MailSettings:MailFrom"];
        }

        public void Send(string subject, string message)
        {
            Debug.WriteLine($"Mail from {MailFrom} to {MailTo}");
            Debug.WriteLine($"Subject:  {subject}");
            Debug.WriteLine($"Message:  {message}");
        }
    }
}
