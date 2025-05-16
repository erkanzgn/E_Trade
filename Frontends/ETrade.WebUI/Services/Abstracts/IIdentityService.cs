using ETrade.DtoLayer.IdentityDtos.LoginDtos;

namespace ETrade.WebUI.Services.Abstracts
{
    public interface IIdentityService
    {
        Task<bool> SingIn(SignInDto singUpDto);
    }
}
