namespace ETrade.WebUI.Services.Abstracts
{
    public interface IClientCredentialTokenService
    {
        Task<string> GetToken();

    }
}
