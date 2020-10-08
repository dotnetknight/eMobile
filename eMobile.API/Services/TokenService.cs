using eMobile.Domain.UsersEntity;
using eMobile.Models.Exceptions;
using eMobile.Models.Responses;
using eMobile.Respository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace eMobile.API.Services
{
    public class TokenService
    {
        #region Properties
        private IRepository<Users> _userRepository;
        public IConfiguration _configuration;
        #endregion

        #region Constructor
        public TokenService(IRepository<Users> userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        #endregion

        public TokenResponse CreateToken(string email, string password)
        {
            var userCredentials = UserCredentialsByEmail(email);

            UserCredentialValidations(password, userCredentials);

            var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, email),
                   };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddDays(90),
                signingCredentials: signIn);

            return new TokenResponse { Token = new JwtSecurityTokenHandler().WriteToken(token) };
        }

        #region Private Methods
        private void UserCredentialValidations(string passwordProvided, Users user)
        {
            if (user == null)
                throw new UserNotFound(System.Net.HttpStatusCode.NotFound, "User not found");

            if (user.Password != PasswordHash(passwordProvided))
                throw new WrongEmailOrPassword(System.Net.HttpStatusCode.Unauthorized, "Incorrect credentials provided");
        }

        private string PasswordHash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            byte[] hashBytes;

            using (var algorithm = new System.Security.Cryptography.SHA512Managed())
                hashBytes = algorithm.ComputeHash(bytes);

            return Convert.ToBase64String(hashBytes);
        }

        private Users UserCredentialsByEmail(string email)
        {
            return _userRepository.GetAll().Where(u => u.Email == email).FirstOrDefault();
        }
        #endregion
    }
}
