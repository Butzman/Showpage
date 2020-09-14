using System;
using System.Threading.Tasks;
using IdentityServer.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MimeKit;

namespace IdentityServer.Services
{
    public class MailerService : IMailerService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;
        private readonly SmtpSettings _smtpSettings;

        public MailerService(
            IOptions<SmtpSettings> smtpSettings,
            IWebHostEnvironment webHostEnvironment,
            IConfiguration configuration )
        {
            _smtpSettings = smtpSettings.Value;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string body)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_smtpSettings.SenderName, _smtpSettings.SenderEmail));
                message.To.Add(new MailboxAddress(email));
                message.Subject = subject;
                message.Body = new TextPart("html")
                {
                    Text = body
                };

                using var client = new SmtpClient
                {
                    ServerCertificateValidationCallback = (s, c, h, e) => true
                };

                if (_webHostEnvironment.IsDevelopment())
                    await client.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, true);
                else
                    await client.ConnectAsync(_smtpSettings.Server);

                await client.AuthenticateAsync(_smtpSettings.Username, _configuration["Passwords:Gmail"]);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }
    }

    public interface IMailerService
    {
        Task SendEmailAsync(string email, string subject, string body);
    }
}