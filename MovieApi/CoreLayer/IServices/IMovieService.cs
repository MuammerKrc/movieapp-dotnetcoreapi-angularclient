using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Dtos;
using CoreLayer.Dtos.MovieDtos;
using CoreLayer.Models;

namespace CoreLayer.IServices
{
    public interface IMovieService
    {
        Task<Response<IEnumerable<MovieDto>>> GetAllMovie();
        Task<Response<MovieDto>> GetMovieById(int id);
        Task<Response<NoResponse>> CreateMovie(MovieDto movie);
        Task<Response<NoResponse>> RemoveMovie(int id);
    }
}
