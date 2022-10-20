using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Models.JwtModels;
using Microsoft.AspNetCore.Identity;

namespace CoreLayer.Models.IdentityModels
{
    public class AppUser : IdentityUser<string>
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public FavoriteMovies FavoriteMovies { get; set; }
        public JWToken JwtToken { get; set; }
    }
}
