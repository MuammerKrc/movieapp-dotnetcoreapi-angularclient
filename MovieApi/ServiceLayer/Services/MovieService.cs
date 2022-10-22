using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Dtos;
using CoreLayer.Dtos.MovieDtos;
using CoreLayer.IServices;

namespace ServiceLayer.Services
{
    public class MovieService:IMovieService
    {
        public Task<Response<IEnumerable<MovieDto>>> GetAllMovie()
        {
            throw new NotImplementedException();
        }

        public Task<Response<MovieDto>> GetMovieById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoResponse>> CreateMovie(MovieDto movie)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoResponse>> RemoveMovie(int id)
        {
            throw new NotImplementedException();
        }
    }
}
