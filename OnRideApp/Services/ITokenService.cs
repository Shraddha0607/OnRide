using Microsoft.AspNetCore.Identity;

namespace OnRideApp.Services;

public interface ITokenService
{
    string CreateJwtToken(IdentityUser user, List<string> roles);
}