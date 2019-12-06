namespace ConsoleApp.Services
{
    public interface IMailService
    {
        MailService BCC(string bcc);
        MailService CC(string cc);
        MailService From(string from, string fromName = null);
        void Send(string subject, string body, bool isBodyHtml = true);
        MailService To(string to);
    }
}