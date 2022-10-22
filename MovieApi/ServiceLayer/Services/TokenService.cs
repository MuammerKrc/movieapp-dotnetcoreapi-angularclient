using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.ConfigurationModels;
using CoreLayer.Dtos;
using CoreLayer.Dtos.TokenDtos;
using CoreLayer.IRepositories;
using CoreLayer.IServices;
using CoreLayer.Models.IdentityModels;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ServiceLayer.Services
{
    public class TokenService : ITokenService
    {
        private TokenConfigurationModel tokenConfigurationModel;

        public TokenService(IOptions<TokenConfigurationModel> tokenOptions)
        {
            tokenConfigurationModel = tokenOptions.Value;
        }

        private SecurityKey GetSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfigurationModel.SecurityKey));
        }

        private string GetRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }
        public Response<TokenDto> CreateAccessToken(AppUser appUser)
        {
            var accessTokenExpiresDate = DateTime.UtcNow.AddSeconds(tokenConfigurationModel.AccessTokenExpirationTime);
            SigningCredentials signingCredential =
                new SigningCredentials(GetSecurityKey(), SecurityAlgorithms.HmacSha256Signature);
            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: tokenConfigurationModel.Issuer,
                audience: tokenConfigurationModel.Audience,
                claims: new List<Claim>() { new Claim(ClaimTypes.Name, appUser.Email) },
                notBefore: DateTime.UtcNow,
                expires: accessTokenExpiresDate,
                signingCredentials: signingCredential);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var accessToken = tokenHandler.WriteToken(jwt);
            var tokenDto = new TokenDto()
            {
                AccessToken = accessToken,
                ExpirationAccessToken = accessTokenExpiresDate,
                ExpirationRefreshToken =
                    accessTokenExpiresDate.AddSeconds(tokenConfigurationModel.RefreshTokenExpirationTime),
                RefresToken = GetRefreshToken()
            };
            return Response<TokenDto>.SuccessResponse(tokenDto);
        }


    }
}
