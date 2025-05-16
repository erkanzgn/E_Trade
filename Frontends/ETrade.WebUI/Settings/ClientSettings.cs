namespace ETrade.WebUI.Settings
{
    public class ClientSettings
    {
        public Client EtradeVisitorClient { get; set; }
        public Client EtradeManagerClient { get; set; }
        public Client EtradeAdminClient { get; set; }
    }
    public class Client
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
