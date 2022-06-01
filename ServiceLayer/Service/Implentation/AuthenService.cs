using DomainLayer.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer;
using ServiceLayer.Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ServiceLayer.Service.Implentation
{
    public class AuthenService : IAuthenService
    {
        private readonly IConfiguration _config;
        private readonly IRefreshTokenRepository _refresh;

        public AuthenService(IConfiguration config, IRefreshTokenRepository refresh)
        {
            _config = config;
            _refresh = refresh;
        }
        public string CreateToken(List<Claim> claims)
        {           
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddSeconds(20),

                signingCredentials: creds); ;
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
        public RefreshToken GenerateRefreshToken(int userId)
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return new RefreshToken() {
                    refreshToken = Convert.ToBase64String(randomNumber),
                    userID = userId,
                    Expires = DateTime.UtcNow.AddSeconds(30)
                };
            }
        }
        public Task<bool> AddRefreshToken(RefreshToken model)
        {
           return _refresh.Add(model);    
        }
        public RefreshToken GetRefreshToken(int userId)
        {
            return _refresh.Get(userId);
        }
        public bool UpdateRefreshToken(RefreshToken model)
        {
            return _refresh.Update(model);
        }
        public ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value)),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            return principal;

        }
    }
}
