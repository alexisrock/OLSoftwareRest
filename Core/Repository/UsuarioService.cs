using AutoMapper;
using Core.Interfaces;
using DataAccess.Interface;
using Domain.DTO;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public class UsuarioService: IUsuarioService
    {

        private readonly IRepositoryUsuario  repository;
        private readonly IConfiguration configuration;
        private readonly string keyEncrypted;
        private readonly string iVEncrypted;
        private readonly string secretKey;
        private readonly string jwtIssuerToken;
        private readonly string jwtAudienceToken;
        private readonly string jwtExpireTime;

        public UsuarioService(IRepositoryUsuario repository, IConfiguration configuration)
        {
            this.repository = repository;
            this.configuration = configuration;
            keyEncrypted = this.configuration["keyEncrypted"];
            iVEncrypted = this.configuration["iVEncrypted"];
            secretKey = this.configuration["secretKey"];
            jwtIssuerToken = this.configuration["jwtIssuerToken"];
            jwtAudienceToken = this.configuration["jwtAudienceToken"];
            jwtExpireTime = this.configuration["jwtExpireTime"];
        }


        public async Task<UserTokenResponse> GetAuthentication(UserTokenRequest userTokenRequest)
        {
            var UserTokenResponse = new UserTokenResponse();

            var user = await ValidateUserName(userTokenRequest.UserName);
            if (user is null)
            {          
                return null; 
            }          
            if (!await ValidatePassword(userTokenRequest.Password, user.Password))
            {                
                return null;
            }
            UserTokenResponse = await MapperUserTokenResponse(user);

            return UserTokenResponse;
        }
        private async Task<Usuario?> ValidateUserName(string? userName)
        {
            var user = await repository.GetByParam(userName);
            return user;
        }      
        public async Task<bool> ValidatePassword(string? password, string encryptedPassword)
        {

            var keyEncrypted = this.keyEncrypted;
            var iVEncrypted = this.iVEncrypted;
            byte[] key = Encoding.UTF8.GetBytes(keyEncrypted);
            byte[] iv = Encoding.UTF8.GetBytes(iVEncrypted);
            using (TripleDES aes = TripleDES.Create())
            {

                ICryptoTransform decryptor = aes.CreateDecryptor(key, iv);
                byte[] encryptedPasswordBytes = Convert.FromBase64String(encryptedPassword);
                byte[] decryptedPasswordBytes = decryptor.TransformFinalBlock(encryptedPasswordBytes, 0, encryptedPasswordBytes.Length);
                string decryptedPassword = Encoding.UTF8.GetString(decryptedPasswordBytes);
                return decryptedPassword == password;
            }
        }
        private async Task<UserTokenResponse> MapperUserTokenResponse(Usuario user)
        {
            UserTokenResponse UserTokenResponse = new();            
            UserTokenResponse.Iduser = user.Id; 
            UserTokenResponse.Token = await GenerateToken(user.Username);
            return UserTokenResponse;
        }
        private async Task<string> GenerateToken(string? userName = "")
        {
            var secretKey =  this.secretKey;
            var jwtIssuerToken =  this.jwtIssuerToken;
            var jwtAudienceToken = this.jwtAudienceToken;
            var jwtExpireTime = this.jwtExpireTime;

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            ClaimsIdentity claimsIdentity = new(new[] { new Claim(ClaimTypes.Name, userName) });
            var currentDate = DateTime.Now;
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: jwtAudienceToken,
                issuer: jwtIssuerToken,
                subject: claimsIdentity,
                notBefore: currentDate,
                expires: currentDate.AddMinutes(Convert.ToInt32(jwtExpireTime)),
                signingCredentials: signingCredentials);
            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
            return jwtTokenString;
        }


        public async Task<bool> ValidateToken(string token)
        {

            try
            {
                var tokenHeader = new JwtSecurityTokenHandler();
                var secreKey = this.secretKey;
                var jwtIssuerToken = this.jwtIssuerToken;
                var jwtAudienceToken = this.jwtIssuerToken;
                var key = Encoding.ASCII.GetBytes(secreKey);
                var tokenParameter = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = jwtIssuerToken,
                    ValidateAudience = true,
                    ValidAudience = jwtAudienceToken,
                    ClockSkew = TimeSpan.Zero
                };

                tokenHeader.ValidateToken(token, tokenParameter, out SecurityToken securutyToken);
                var jwtToken = (JwtSecurityToken)securutyToken;
                var isOk = await SearchUser(jwtToken.Claims.First(t => t.Type == "unique_name").Value);
                return isOk;
            }
            catch
            {
                return false;
            }
        }



        private async Task<bool> SearchUser(string username)
        {
            var user = await repository.GetByParam(username);
            return user != null;
        }
    }
}
