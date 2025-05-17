using ETrade.DtoLayer.IdentityDtos.LoginDtos;
using ETrade.WebUI.Services.Abstracts;
using ETrade.WebUI.Settings;
using IdentityModel.AspNetCore.AccessTokenManagement;
using IdentityModel.Client;
using Microsoft.Extensions.Options;


namespace ETrade.WebUI.Services.Concrete
{
    public class ClientCredentialTokenService : IClientCredentialTokenService
    {
        private readonly ServiceApiSettings _serviceApiSettings;
        private readonly HttpClient _httpClient;
        private readonly IClientAccessTokenCache _clientAccessTokenCache;
        private readonly ClientSettings _clientSettings;

        public ClientCredentialTokenService(IOptions<ServiceApiSettings> serviceApiSettings, HttpClient httpClient,
            IClientAccessTokenCache clientAccessTokenCache, IOptions<ClientSettings>clienSettings)
        {
            _serviceApiSettings = serviceApiSettings.Value;
            _httpClient = httpClient;
            _clientAccessTokenCache = clientAccessTokenCache;
            _clientSettings = clienSettings.Value;
        }

        public async  Task<string> GetToken()
        {
            var token1 = await _clientAccessTokenCache.GetAsync("etradetoken");
            if (token1 != null)
            {
                return token1.AccessToken;
            }
            var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _serviceApiSettings.IdentityServerUrl,
                Policy = new DiscoveryPolicy
                {
                    RequireHttps = false
                }

            });
            var clientCredentialTokenRequest = new ClientCredentialsTokenRequest
            {
                ClientId = _clientSettings.EtradeVisitorClient.ClientId,
                ClientSecret = _clientSettings.EtradeVisitorClient.ClientSecret,
                Address = discoveryEndPoint.TokenEndpoint
            };
            var token2= await _httpClient.RequestClientCredentialsTokenAsync(clientCredentialTokenRequest);
            await _clientAccessTokenCache.SetAsync("etradetoken", token2.AccessToken, token2.ExpiresIn);
            return token2.AccessToken;
        }
    }

}