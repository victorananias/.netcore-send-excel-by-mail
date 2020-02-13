namespace SendExcelByEmail.Services
{
    public interface IMailService
    {
        MailService From(string from, string fromName = null);
        MailService CC(string cc);
        MailService BCC(string bcc);
        MailService To(string to);
        void Send(string subject, string body, bool isBodyHtml = true);
    }
}