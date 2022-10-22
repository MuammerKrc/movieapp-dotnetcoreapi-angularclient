using CoreLayer.Models.IdentityModels;
using CoreLayer.Models.JwtModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Dtos;
using CoreLayer.Dtos.TokenDtos;

namespace CoreLayer.IServices
{
    public interface ITokenService
    {
        Response<TokenDto> CreateAccessToken(AppUser appUser);
    }
}
