using CoreLayer.Dtos.MovieDtos;
using CoreLayer.IServices;
using DataLayer.DbContexts;
using Microsoft.AspNetCore.Mvc;

namespace MovieApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MoviesController:ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var result = await _movieService.GetAllMovie();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _movieService.GetMovieById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie(MovieCreateDto dto)
        {
            var result = await _movieService.CreateMovie(dto);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var result = await _movieService.RemoveMovie(id);
            return Ok(result);
        }
    }
}
