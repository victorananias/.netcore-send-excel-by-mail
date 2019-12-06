using System;
using System.Net;
using System.Net.Mail;

namespace ConsoleApp.Services
{
    public class MailService : IMailService
    {
        private readonly string _host;
        private readonly int _port;
        private string _cc;
        private string _bcc;
        private string _to;
        private MailAddress _from;
        private readonly NetworkCredential _credentials;

        public MailService(string host, int port, string username, string password)
        {
            _host = host;
            _port = port;
            _from = new MailAddress(username);
            _credentials = new NetworkCredential(username, password);
        }

        public MailService From(string from, string fromName = null)
        {
            _from = new MailAddress(from, fromName);
            return this;
        }

        public MailService CC(string cc)
        {
            _cc = cc;
            return this;
        }

        public MailService BCC(string bcc)
        {
            _bcc = bcc;
            return this;
        }

        public MailService To(string to)
        {
            _to = to;
            return this;
        }

        public void Send(string subject, string body, bool isBodyHtml = true)
        {
            try
            {
                using SmtpClient client = new SmtpClient(_host, _port)
                {
                    EnableSsl = true,
                    Credentials = _credentials
                };

                MailMessage message = new MailMessage
                {
                    From = _from,
                    Subject = subject,
                    Body = body
                };

                AddAdress(message.To, _to);
                AddAdress(message.CC, _cc);
                AddAdress(message.Bcc, _bcc);

                message.IsBodyHtml = isBodyHtml;

                client.Send(message);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void AddAdress(MailAddressCollection mail, string adresses)
        {
            foreach (var address in adresses.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
            {
                mail.Add(address);
            }
        }
    }
}