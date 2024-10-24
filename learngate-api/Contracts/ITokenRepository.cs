using Microsoft.AspNetCore.Identity;

namespace learngate_api.Contracts
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);

    }
}
