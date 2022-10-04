using System;
using System.Net;
using System.Net.Mail;
using MySql.Data.MySqlClient;
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
        public Email()
        {

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
        public bool SendAuthenticationNumber(string randomNumber)
        {
            bool status = false;
            // password 지우기
            string connStr = "Server=localhost;Database=test_users;Uid=root;Pwd=password;";
            // 5자리 랜덤 숫자 보내고 만약에 입력값이 일치하면 true, 그렇지 않다면 false
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM host WHERE id=1";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        string? temp_host = rdr["email"].ToString();
                        string? temp_host_secondaryPassword = rdr["secondary_password"].ToString();
                        if (!String.IsNullOrEmpty(temp_host) && !String.IsNullOrEmpty(temp_host_secondaryPassword))
                        {
                            host = temp_host;
                            host_secondaryPassword = temp_host_secondaryPassword;
                        }
                    }
                    rdr.Close();
                    Send();
                    Console.WriteLine("Please check {0} email address and enter 5 numbers", receiver);
                    for(int i =0; i < 5; i++)
                    {
                        if (i == 4)
                        {
                            Console.WriteLine("[Warning] Last chance");
                        }
                        Console.WriteLine("Enter a number> ");
                        if (randomNumber == Console.ReadLine())
                        {
                            status = true;
                            break;
                        }
                    }
                    if(!status)
                        Console.WriteLine("[Information] Failed, Please try again");
                } catch(Exception e)
                {
                    Console.WriteLine("[Warning in Email class] error happened while reading a data in host table");
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.HelpLink);
                }
                finally
                {
                    connection.Close();
                }
                return status;
            }
        }
    }
}

