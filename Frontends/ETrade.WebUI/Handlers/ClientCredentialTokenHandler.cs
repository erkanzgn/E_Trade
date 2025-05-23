using System.Net;
using System.Net.Http.Headers;
using ETrade.WebUI.Services.Abstracts;

namespace ETrade.WebUI.Handlers
{
    public class ClientCredentialTokenHandler:DelegatingHandler
    {
        private readonly IClientCredentialTokenService _clientCredentialTokenService;
        private readonly IHttpContextAccessor _contextAccessor;
        public ClientCredentialTokenHandler(IClientCredentialTokenService clientCredentialTokenService, IHttpContextAccessor contextAccessor)
        {
            _clientCredentialTokenService = clientCredentialTokenService;
            _contextAccessor = contextAccessor;
        }


        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await _clientCredentialTokenService.GetToken());
            var response = await base.SendAsync(request, cancellationToken);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                //hata mesajı
            }
            return response;
        }
    }
}
