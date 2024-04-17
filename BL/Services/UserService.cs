using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Core.Interfaces;
using Core.Models;

using Microsoft.IdentityModel.Tokens;

namespace BL.Services
{
    public class UserService : IUserService
    {
        public string GenerateJSONWebToken(UserModel userInfo,string jwtKey,string jwtIssuer)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(jwtIssuer,
                jwtIssuer,
                null,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public UserModel AuthenticateUser(UserModel login)
        {
            UserModel user = null;

            //Validate the User Credentials
            //Demo Purpose, I have Passed HardCoded User Information
            if (login.Username == "Test")
            {
                user = new UserModel { Username = "Test", Password = "Test" };
            }

            return user;
        }
    }
}
