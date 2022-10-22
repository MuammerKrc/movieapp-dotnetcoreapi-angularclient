using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.ConfigurationModels;
using CoreLayer.Dtos;
using CoreLayer.Dtos.IdentityDtos;
using CoreLayer.Dtos.TokenDtos;
using CoreLayer.Exceptions;
using CoreLayer.IRepositories;
using CoreLayer.IServices;
using CoreLayer.Models.IdentityModels;
using CoreLayer.Models.JwtModels;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        public AuthService(UserManager<AppUser> userManager, ITokenService tokenService, IUserService userService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _userService = userService;
        }

        public async Task<Response<TokenDto>> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
                throw new AuthenticationErrorException();
            var resultPassword = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!resultPassword)
                throw new AuthenticationErrorException();
            var tokenResponse = _tokenService.CreateAccessToken(user);
            await _userService.UpdateRefreshTokenAsync(tokenResponse.Data.RefresToken, user, tokenResponse.Data.ExpirationRefreshToken);
            return tokenResponse;
        }

        public async Task<Response<TokenDto>> RefreshTokenLoginAsync(string refreshToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(e => e.RefreshToken == refreshToken && e.RefreshTokenEndDate > DateTime.UtcNow);
            if (user != null && user?.RefreshTokenEndDate > DateTime.UtcNow)
            {
                var tokenresponse = _tokenService.CreateAccessToken(user);
                await _userService.UpdateRefreshTokenAsync(tokenresponse.Data.RefresToken, user,
                    tokenresponse.Data.ExpirationRefreshToken);
                return tokenresponse;
            }
            else
                throw new NotFoundEntityException("User Not found");
        }
    }
}
