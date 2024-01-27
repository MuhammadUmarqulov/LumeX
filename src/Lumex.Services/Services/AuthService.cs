using Lumex.Data.IRepositories;
using Lumex.Domain.Entities;
using Lumex.Service.Extentions;
using Lumex.Services.Exceptions;
using Lumex.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Lumex.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly IGenericRepository<User> repository;
        private readonly IConfiguration configuration;

        public AuthService(IGenericRepository<User> repository, IConfiguration configuration)
        {
            this.repository = repository;
            this.configuration = configuration;
        }
        public async ValueTask<string> GenerateToken(string username, string password)
        {
            User user = await repository.GetAsync(u =>
                u.Email == username && u.Password.Equals(password.Encrypt()));

            if (user is null)
                throw new LumexException(400, "Login or Password is incorrect");

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            byte[] tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);

            SecurityTokenDescriptor tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddMonths(int.Parse(configuration["JWT:Lifetime"])),
                Issuer = configuration["JWT:Issuer"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);
        }
    }
}
