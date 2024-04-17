using Core.Models;

namespace Core.Interfaces
{
    public interface IUserService
    {
        public string GenerateJSONWebToken(UserModel userInfo, string jwtKey, string jwtIssuer);

        public UserModel AuthenticateUser(UserModel login);
    }
}
