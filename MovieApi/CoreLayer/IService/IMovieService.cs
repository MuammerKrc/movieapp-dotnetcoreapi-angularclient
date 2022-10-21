using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Dtos.MovieDtos;
using CoreLayer.Models;

namespace CoreLayer.IService
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDto>> GetAllMovie();
        Task<Movie> GetMovieById(int id);
        Task AddMovie(MovieDto movie);
        Task RemoveMovie(int id);
    }
}
