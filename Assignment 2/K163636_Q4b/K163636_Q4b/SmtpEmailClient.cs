using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace K163636_Q4b
{
    public class SmtpEmailClient
    {
        private string email;
        private string password;
        NetworkCredential login;
        SmtpClient client;
        MailMessage message;

        public SmtpEmailClient()
        {
            email = "bilal752102@gmail.com";
            password = "b03162162334B";
        }

        public void SendEmail(string SenderEmail)
        {
            login = new NetworkCredential(email,password);
            client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = login;
            message = new MailMessage { From = new MailAddress(email, "Medical Record Email", Encoding.UTF8) };
            message.To.Add(new MailAddress(SenderEmail));
            message.Subject = "Hello";
            message.Body = "group made";
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            message.Priority = MailPriority.Normal;
            message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            client.SendCompleted += new SendCompletedEventHandler(sendCompletedCallBack);
            string userstate = "Sending...";
            client.SendAsync(message, userstate);
        }

        private void sendCompletedCallBack(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
                Console.WriteLine(e.UserState);
            else if (e.Error != null)
            {
                Console.WriteLine(e.Error);
            }
            else
            {
                Console.WriteLine("Success");
            }
        }
    }
}
