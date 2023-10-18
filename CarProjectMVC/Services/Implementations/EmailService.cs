using CarProjectMVC.Areas.Identity.Data;
using CarProjectMVC.Services.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;

namespace CarProjectMVC.Services.Implementations
{
    /// <summary>
    /// Сервис для отправки Email-сообщений пользователю.
    /// </summary>
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(User user, string subject, string message)
        {
            using MimeMessage emailMessage = new();

            emailMessage.From.Add(new MailboxAddress("Car WebApplication", "car.webapplication@mail.ru"));
            emailMessage.To.Add(new MailboxAddress(user.Login, user.Email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using SmtpClient client = new();
            await client.ConnectAsync("smtp.mail.ru", 25, false);
            await client.AuthenticateAsync("car.webapplication@mail.ru", "nifariankek322!");
            await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true);
        }
    }
}
