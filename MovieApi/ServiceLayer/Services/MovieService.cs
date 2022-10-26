using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CoreLayer.Dtos;
using CoreLayer.Dtos.MovieDtos;
using CoreLayer.IServices;
using CoreLayer.IUnitOfWorks;
using CoreLayer.Models;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace ServiceLayer.Services
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public MovieService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Response<IEnumerable<MovieDto>>> GetAllMovie()
        {
            var response = await _unitOfWork.MovieRepository.GetAllAsync();
            return Response<IEnumerable<MovieDto>>.SuccessResponse(mapper.Map<IEnumerable<MovieDto>>(response));
        }

        public async Task<Response<MovieDto>> GetMovieById(int id)
        {
            var response = await _unitOfWork.MovieRepository.GetByIdAsync(id);
            return Response<MovieDto>.SuccessResponse(mapper.Map<MovieDto>(response));
        }

        public async Task<Response<NoResponse>> CreateMovie(MovieCreateDto movie)
        {
            _unitOfWork.MovieRepository.Add(mapper.Map<Movie>(movie));
            await _unitOfWork.SaveAsync();
            return Response<NoResponse>.SuccessResponse();

        }

        public async Task<Response<NoResponse>> RemoveMovie(int id)
        {
            await _unitOfWork.MovieRepository.SoftDelete(id);
            await _unitOfWork.SaveAsync();
            return Response<NoResponse>.SuccessResponse();
        }
    }
}
