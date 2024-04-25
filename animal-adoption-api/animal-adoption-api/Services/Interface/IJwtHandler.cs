using animal.adoption.api.DTO.HelperModels;
using animal.adoption.api.DTO.HelperModels.Jwt;
using animal.adoption.api.Models;

namespace animal.adoption.api.Services.Interface
{
    public interface IJwtHandler
    {
        JwtResponse CreateToken(JwtCustomClaims claims);
    }
}
