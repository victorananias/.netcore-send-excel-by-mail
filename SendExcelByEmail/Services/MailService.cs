using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using Microsoft.Extensions.Options;
using SendExcelByEmail.Settings;

namespace SendExcelByEmail.Services
{
    public class MailService : IMailService
    {
        private string _host;
        private int _port;
        private string _cc;
        private string _bcc;
        private string _to;
        private MailAddress _from;
        private NetworkCredential _credentials;
        private List<Attachment> _attachments;

        public MailService(IOptions<AppSettings> appSettings)
        {
            _attachments = new List<Attachment>();

            var settings = appSettings.Value.MailSettings;
            _host = settings.Host;
            _port = settings.Port;

            try
            {
                _from = new MailAddress(string.IsNullOrEmpty(settings.From) ? settings.Username : settings.From);
            }
            catch (Exception e)
            {
                // ignored
            }

            _credentials = new NetworkCredential(settings.Username, settings.Password);
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

        public IMailService AddAttachment(Stream stream, string mediaType, string name)
        {
            var attachment = new Attachment(stream, name, mediaType);
            _attachments.Add(attachment);
            return this;
        }

        public void Send(string subject, string body, bool isBodyHtml = true)
        {
            using var client = new SmtpClient(_host, _port)
            {
                EnableSsl = true,
                Credentials = _credentials
            };

            var message = new MailMessage
            {
                From = _from,
                Subject = subject,
                Body = body,
                IsBodyHtml = isBodyHtml
            };

            AddAttachmentsToMessage(message);
            AddAdressToMailCollection(message.To, _to);
            AddAdressToMailCollection(message.CC, _cc);
            AddAdressToMailCollection(message.Bcc, _bcc);

            client.Send(message);
        }

        private void AddAttachmentsToMessage(MailMessage message)
        {
            _attachments.ForEach(attachment => message.Attachments.Add(attachment));
        }

        private void AddAdressToMailCollection(MailAddressCollection mail, string adresses)
        {
            if (string.IsNullOrEmpty(adresses))
            {
                return;
            }

            foreach (var address in adresses.Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries))
            {
                mail.Add(address);
            }
        }
    }
}