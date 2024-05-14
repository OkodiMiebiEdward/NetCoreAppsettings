using System.Collections.Generic;

namespace NetCoreAppsettings.Options
{
    public class EmailSettingsOptions
    {
        public bool EnableEmailSystem { get; set; }
        public int EmailTimeOutInSeconds { get; set; }
        public List<string> EmailServers { get; set; } = new List<string>();
        public EmailAdmin EmailAdmin { get; set; } = new EmailAdmin();
    }
}
