using CoreLayer.Models.JwtModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Dtos;
using CoreLayer.Dtos.TokenDtos;
using CoreLayer.Dtos.IdentityDtos;

namespace CoreLayer.IServices
{
    public interface IAuthService
    {
        Task<Response<TokenDto>> LoginAsync(LoginDto dto);
        Task<Response<TokenDto>> RefreshTokenLoginAsync(string refreshToken);
    }
}
