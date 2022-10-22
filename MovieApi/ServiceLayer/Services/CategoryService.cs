using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CoreLayer.Dtos;
using CoreLayer.Dtos.CategoryDtos;
using CoreLayer.IRepositories;
using CoreLayer.IServices;
using CoreLayer.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;


namespace ServiceLayer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<CategoryDto>>> GetAllCategory()
        {
            var response = await _categoryRepository.GetAllAsync();

            return Response<IEnumerable<CategoryDto>>.SuccessResponse(_mapper.Map<List<CategoryDto>>(response));
        }

        public async Task<Response<CategoryDto>> GetCategoryWithMovieById(int id)
        {
            var response = await _categoryRepository.GetWhereAsync(i => i.Id == id).Include(i => i.Movies).ToListAsync();
            return Response<CategoryDto>.SuccessResponse(_mapper.Map<CategoryDto>(response));
        }

        public async Task<Response<NoResponse>> CreateCategory(CategoryDto category)
        {
            var categoryModel = _mapper.Map<Category>(category);
            _categoryRepository.Add(categoryModel);

            return Response<NoResponse>.SuccessResponse();
        }
    }
}
