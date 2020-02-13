namespace SendExcelByEmail.Settings
{
    public class MailSettings
    {
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string From { get; set; }
        public string CC { get; set; }
        public string BCC { get; set; }
        public int Port { get; set; }
    }
}