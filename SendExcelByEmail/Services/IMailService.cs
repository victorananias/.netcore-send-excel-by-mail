using System.IO;

namespace SendExcelByEmail.Services
{
    public interface IMailService
    {
        IMailService From(string from, string fromName = null);
        IMailService CC(string cc);
        IMailService BCC(string bcc);
        IMailService To(string to);
        IMailService AddAttachment(Stream stream, string mediaType, string name);
        void Send(string subject, string body, bool isBodyHtml = true);
    }
}