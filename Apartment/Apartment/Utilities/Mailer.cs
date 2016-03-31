using System.Net;
using System.Net.Mail;

namespace Apartment.Utilities
{
    public class Mailer
    {
        public static void SendLink(string emailTitle, string receipiant, string mailMessage)
        {
            var message = new MailMessage();
            message.To.Add(new MailAddress(receipiant));
            message.From = new MailAddress("DCCApartment@system.com");
            message.Subject = emailTitle;
            message.Body = $"{mailMessage}";
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "dcc.apartments32516@gmail.com",
                    Password = "Testing2@"
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(message);
            }
        }
        //add case ID to parameter
        public static void SendEmail(string applicantSender, string applicantEmail)
        {

            var message = new MailMessage();
            message.To.Add(new MailAddress("dcc.apartments32516@gmail.com"));
            message.From = new MailAddress("DCCApartment@system.com");
            message.Subject = "Application Submitted!";
            string mailMessage = $"{applicantSender} has submitted their application. Please change their status to 'Pending Approval'!<p><a href='http://localhost:17455/Cases/Index' target='_blank'>Cases Index</a></p><p>If they already do not have a case already, please create one. Email is {applicantEmail}.";
            message.Body = mailMessage;
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "dcc.apartments32516@gmail.com",
                    Password = "Testing2@"
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(message);
            }
        }

        public static void SendUserEmail(string fromName, string fromUser, string subject, string userMessage)
        {
            var message = new MailMessage();
            message.To.Add(new MailAddress("dcc.apartments32516@gmail.com"));
            message.From = new MailAddress(fromUser);
            message.Subject = subject;
            message.Body = $"<p>From: {fromName} </p><p>Email: {fromUser}</p><p>Subject: {subject}</p><p>Message: {userMessage}</p>";
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "dcc.apartments32516@gmail.com",
                    Password = "Testing2@"
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(message);
            }
        }
    }
}