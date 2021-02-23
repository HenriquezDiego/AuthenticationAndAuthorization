using AuthenticationAndAuthorization.Models;

namespace AuthenticationAndAuthorization.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
