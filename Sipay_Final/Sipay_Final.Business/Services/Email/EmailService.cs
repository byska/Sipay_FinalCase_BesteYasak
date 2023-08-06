using Microsoft.Extensions.Options;
using PayInformationModel=Sipay_Final.Entities.DbSets;
using System.Net;
using System.Net.Mail;

namespace Sipay_Final.Business.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> options)
        {
            _emailSettings = options.Value;
        }

        public async Task SendReminder(string ToEmail, int? waterBill, int? electricityBill, int? gasBill, int? dues)
        {
            var smtpClient = new SmtpClient();

            smtpClient.Host = _emailSettings.Host;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(_emailSettings.Email,_emailSettings.Password);
            smtpClient.EnableSsl = true;

            var mailMessage = new MailMessage();

            mailMessage.From = new MailAddress(_emailSettings.Email);
            mailMessage.To.Add(ToEmail);

            mailMessage.Subject = "Localhost | Ödenmemiş Fatura Hatırlatma";
            mailMessage.Body = @$"
                <h4>Ödenmemiş faturanız bulunmaktadır. Fatura bilgileriniz aşağıda mevcuttur.</h4>;
            <p> Aidat:{dues}</p>
            <p> Su Faturası:{waterBill}</p>
            <p> Doğalgaz Faturası:{gasBill}</p>
            <p> Elektrik Faturası:{electricityBill}</p>";

            mailMessage.IsBodyHtml = true;

            await smtpClient.SendMailAsync(mailMessage);



        }
    }
}
