using CoreLayer.Models.IdentityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Dtos;
using CoreLayer.Dtos.IdentityDtos;

namespace CoreLayer.IServices
{
    public interface IUserService
    {
        Task<Response<NoResponse>> CreateAsync(CreateUserDto model);
        Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime refreshTokenExpiration);
        Task UpdatePasswordAsync(string userId, string resetToken, string newPassword);
    }
}
