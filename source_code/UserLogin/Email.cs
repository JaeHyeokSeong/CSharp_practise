using System;
using System.Net;
using System.Net.Mail;
namespace UserLogin
{
    public class Email
    {
        private bool sent = false;
        private string host = "";
        private string host_secondaryPassword = "";
        private string subject = "", body = "", receiver = "";
        public bool Sent
        {
            get { return sent; }
        }
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        public string Body
        {
            get { return body; }
            set { body = value; }
        }
        public string Receiver
        {
            get { return receiver; }
            set { receiver = value; }
        }
        public Email(string host, string host_secondaryPassword)
        {
            this.host = host;
            this.host_secondaryPassword = host_secondaryPassword;
        }
        public void Send()
        {
            try
            {
                // Credentials
                var credentials = new NetworkCredential(host, host_secondaryPassword);

                // Mail message
                var mail = new MailMessage()
                {
                    From = new MailAddress("seong5763@gmail.com"),
                    Subject = this.subject,
                    Body = this.body
                };
                mail.To.Add(new MailAddress(this.receiver));

                // Smtp client
                var client = new SmtpClient()
                {
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = "smtp.gmail.com",
                    EnableSsl = true,
                    Credentials = credentials
                };

                // Send it...
                Console.WriteLine("[Current status] Sending...");
                client.Send(mail);
                Console.WriteLine("[Current status] Sent");
                sent = true;
            } catch(Exception e)
            {
                Console.WriteLine("[Warning] Error happened while sending an mail");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.HelpLink);
            }
        }
        public bool SendAuthenticationNumber()
        {
            // 5자리 랜덤 숫자 보내고 만약에 입력값이 일치하면 true, 그렇지 않다면 false
            if (true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

