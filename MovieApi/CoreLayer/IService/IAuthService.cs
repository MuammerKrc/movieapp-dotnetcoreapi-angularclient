using CoreLayer.Models.JwtModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Dtos.TokenDtos;

namespace CoreLayer.IService
{
    public interface IAuthService
    {
        Task<TokenDto> LoginAsync();
        Task<TokenDto> RefreshTokenLoginAsync(string refreshToken);
    }
}
