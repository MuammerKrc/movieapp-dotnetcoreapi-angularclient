using CoreLayer.Models.IdentityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Dtos.IdentityDtos;

namespace CoreLayer.Dtos.TokenDtos
{
    public class TokenDto
    {
        public string AccessToken { get; set; }
        public string RefresToken { get; set; }
        public DateTime ExpirationAccessToken { get; set; }
        public DateTime ExpirationRefreshToken { get; set; }
        public string UserId { get; set; }
        public AppUserDto User { get; set; }
    }
}
