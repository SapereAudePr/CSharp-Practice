using Microsoft.AspNetCore.Identity;

namespace WebAPIDemo.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
