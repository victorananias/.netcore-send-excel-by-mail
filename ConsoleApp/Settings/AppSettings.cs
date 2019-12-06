using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Settings
{
    class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
    }

    class Mail
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public Mail Mail { get; set; }

    }
}
