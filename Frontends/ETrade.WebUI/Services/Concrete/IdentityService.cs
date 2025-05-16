using Duende.IdentityModel.Client;
using ETrade.DtoLayer.IdentityDtos.LoginDtos;
using ETrade.WebUI.Services.Abstracts;
using ETrade.WebUI.Settings;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Security.Claims;


namespace ETrade.WebUI.Services.Concrete
{
    public class IdentityService : IIdentityService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ClientSettings _clientSettings;

        public IdentityService(HttpClient httpClient, IHttpContextAccessor contextAccessor, IOptions<ClientSettings> clientSettings)
        {
            _httpClient = httpClient;
            _contextAccessor = contextAccessor;
            _clientSettings = clientSettings.Value;
        }

        public async Task<bool> SingIn(SignInDto signInDto)
        {
            var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = "http://localhost:5001",
                Policy = new DiscoveryPolicy
                {
                    RequireHttps = false
                }

            });
            var passworTokenRequest = new PasswordTokenRequest
            {
                ClientId = _clientSettings.EtradeManagerClient.ClientId,
                ClientSecret = _clientSettings.EtradeManagerClient.ClientSecret,
                UserName = signInDto.Username,
                Password = signInDto.Password,
                Address = discoveryEndPoint.TokenEndpoint
            };
            var token = await _httpClient.RequestPasswordTokenAsync(passworTokenRequest);

            var userInfoRequest = new UserInfoRequest
            {
                Token = token.AccessToken,
                Address = discoveryEndPoint.UserInfoEndpoint,
            };
            var userValues=await _httpClient.GetUserInfoAsync(userInfoRequest);

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(userValues.Claims, CookieAuthenticationDefaults.AuthenticationScheme, "name", "role");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var authenticationProperties = new AuthenticationProperties();
            authenticationProperties.StoreTokens(new List<AuthenticationToken>()
            {
                new AuthenticationToken
                {
                    Name=OpenIdConnectParameterNames.AccessToken,
                    Value=token.AccessToken
                },
                new  AuthenticationToken
                {
                    Name=OpenIdConnectParameterNames.RefreshToken,
                    Value=token.RefreshToken
                },
                new AuthenticationToken
                {
                    Name=OpenIdConnectParameterNames.ExpiresIn,
                    Value=DateTime.Now.AddSeconds(token.ExpiresIn).ToString()
                }
            });

            authenticationProperties.IsPersistent=false;

            await _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                claimsPrincipal, authenticationProperties);


            return true;

        }
    }
}
