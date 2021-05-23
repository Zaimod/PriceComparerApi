using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceComparer.Services
{
    public class EmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("PriceComparerAPI", "pricecomparerapi@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, false);
                await client.AuthenticateAsync("pricecomparerapi@gmail.com", "priceComparer");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }

        public string GenerateCode()
        {
            Random generator = new Random();
            string code = generator.Next(0, 1000000).ToString("D6");

            return code;
        }
    }
}
