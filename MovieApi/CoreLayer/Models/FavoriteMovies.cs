using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Models.BaseModels;
using CoreLayer.Models.IdentityModels;

namespace CoreLayer.Models
{
    public class FavoriteMovies : BaseModel<int>
    {
        public AppUser User { get; set; }
        public string UserId { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
