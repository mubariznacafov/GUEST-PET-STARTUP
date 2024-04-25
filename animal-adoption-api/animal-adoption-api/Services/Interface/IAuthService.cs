using animal.adoption.api.DTO.HelperModels.Jwt;
using animal.adoption.api.DTO.RequestModels.Auth;
using animal.adoption.api.DTO.ResponseModels.Main;

namespace animal.adoption.api.Services.Interface
{
    public interface IAuthService
    {
        Task<ResponseSimple> RegisterUserAsync(ResponseSimple response, RegisterDto model);
        Task<ResponseObject<JwtResponse>> LoginAsync(ResponseObject<JwtResponse> response, LoginDto model);
        Task<ResponseSimple> ForgotPasswordAsync(ResponseSimple response, string email);
        Task<ResponseSimple> ResetPasswordAsync(ResponseSimple response, ResetPasswordDto model);
        Task<ResponseSimple> ChangePasswordAsync(ResponseSimple response, ChangePasswordDto model);
    }
}
