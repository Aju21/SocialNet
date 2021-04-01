using SocialNet.API.Models;

namespace SocialNet.API.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User usr);
    }
}