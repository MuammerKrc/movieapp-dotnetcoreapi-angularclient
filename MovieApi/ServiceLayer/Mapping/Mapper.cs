using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CoreLayer.Dtos.CategoryDtos;
using CoreLayer.Dtos.MovieDtos;
using CoreLayer.Models;

namespace ServiceLayer.Mapping
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<MovieCreateDto, Movie>().ReverseMap();
        }
    }
}
