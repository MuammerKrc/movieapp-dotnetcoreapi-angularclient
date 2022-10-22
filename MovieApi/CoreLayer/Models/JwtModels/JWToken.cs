using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Models.BaseModels;
using CoreLayer.Models.IdentityModels;

namespace CoreLayer.Models.JwtModels
{
    public class JWToken 
    {
        public string AccessToken { get; set; }
        public string RefresToken { get; set; }
        public DateTime ExpirationAccessToken { get; set; }
        public DateTime ExpirationRefreshToken { get; set; }
    }
}
