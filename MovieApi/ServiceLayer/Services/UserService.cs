using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Dtos;
using CoreLayer.Dtos.IdentityDtos;
using CoreLayer.Exceptions;
using CoreLayer.IRepositories;
using CoreLayer.IServices;
using CoreLayer.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;

namespace ServiceLayer.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Response<NoResponse>> CreateAsync(CreateUserDto model)
        {
            try
            {
                IdentityResult result = await _userManager.CreateAsync(new AppUser()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = model.Name,
                    Surname = model.Surname,
                    FullName = (model.Name ?? "") + " " + (model.Surname ?? ""),
                    Email = model.Email,
                    UserName = Guid.NewGuid().ToString()
                }, model.Password);

                if (!result.Succeeded)
                    return Response<NoResponse>.ErrorResponse(result.Errors.Select(i => i.Description).ToList());
                return Response<NoResponse>.SuccessResponse(message: "Kullanıcı başarı ile oluşturuldu");
            }
            catch (Exception e)
            {
                throw new UserCreateException();
            }
        }

        public async Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime refreshExpirationDate)
        {
            user.RefreshToken = refreshToken;
            user.RefreshTokenEndDate = refreshExpirationDate;
            await _userManager.UpdateAsync(user);
        }



        public Task UpdatePasswordAsync(string userId, string resetToken, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
