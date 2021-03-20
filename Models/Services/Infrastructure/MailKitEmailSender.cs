using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using Scadenzario.Models.Options;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using Microsoft.Extensions.Logging;

namespace Scadenzario.Models.Services.Infrastructure
{
    public class MailKitEmailSender : IEmailSender
    {
        private readonly IOptionsMonitor<SmtpOptions> smtpOptionsMonitor;
        private readonly ILogger<MailKitEmailSender> logger;
        public MailKitEmailSender(IOptionsMonitor<SmtpOptions> smtpOptionsMonitor, ILogger<MailKitEmailSender> logger)
        {
            this.logger = logger;
            this.smtpOptionsMonitor = smtpOptionsMonitor;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                var options = this.smtpOptionsMonitor.CurrentValue;
                using SmtpClient client = new();
                await client.ConnectAsync(options.Host, options.Port, options.Security);
                if (!string.IsNullOrEmpty(options.Username))
                {
                    await client.AuthenticateAsync(options.Username, options.Password);
                }
                MimeMessage message = new();
                message.From.Add(MailboxAddress.Parse(options.Sender));
                message.To.Add(MailboxAddress.Parse(email));
                message.Subject = subject;
                message.Body = new TextPart("html")
                {
                    Text = htmlMessage
                };
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
            catch (Exception exc)
            {
                logger.LogError(exc, "Couldn't send email to {email} with message {message}", email, htmlMessage);
            }
        }
    }
}