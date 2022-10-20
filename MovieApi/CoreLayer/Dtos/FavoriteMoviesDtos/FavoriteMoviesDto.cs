using CoreLayer.Models.IdentityModels;
using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Dtos.IdentityDtos;
using CoreLayer.Dtos.MovieDtos;

namespace CoreLayer.Dtos.FavoriteMoviesDtos
{
    public class FavoriteMoviesDto : BaseDto<int>
    {
        public AppUserDto User { get; set; }
        public string UserId { get; set; }
        public ICollection<MovieDto> Movies { get; set; }
    }
}
