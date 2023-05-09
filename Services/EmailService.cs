using AspNetCoreIdentityApp.Web.OptionsModels;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace AspNetCoreIdentityApp.Web.Services
{
    public class EmailService:IEmailService
    {
        private readonly EmailSettings _emailSettings;
        public EmailService(IOptions<EmailSettings> options)
        {
            _emailSettings = options.Value;
        }
        public async Task SendResetPasswordEmail(string resetPasswordEmailLink, string ToEmail)
        {
            var smtpClient = new SmtpClient();
            smtpClient.Host =_emailSettings.Host;
            smtpClient.DeliveryMethod=SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(_emailSettings.Email,_emailSettings.Password);
            smtpClient.EnableSsl = true;
            var mailmessage=new MailMessage();
            mailmessage.From = new MailAddress(_emailSettings.Email);
            mailmessage.To.Add(ToEmail);
            mailmessage.Subject = "LocalHost | Şifre Sıfırlama Linki";
            mailmessage.Body = $@"<h4>Şifrenizi yenilemek için aşağıdaki linke tıklayınız.</h4>
                <p><a href='{resetPasswordEmailLink}'>Şifre Yenileme Linki</a></p>";
            mailmessage.IsBodyHtml = true;
            await smtpClient.SendMailAsync(mailmessage);
        }
    }
}
