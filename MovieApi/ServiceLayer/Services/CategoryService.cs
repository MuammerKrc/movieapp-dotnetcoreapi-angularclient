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
using CoreLayer.IUnitOfWorks;
using CoreLayer.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;


namespace ServiceLayer.Services
{
    public class CategoryService : ICategoryService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;


        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<CategoryDto>>> GetAllCategory()
        {
            var response = await _unitOfWork.CategoryRepository.GetAllAsync();

            return Response<IEnumerable<CategoryDto>>.SuccessResponse(_mapper.Map<List<CategoryDto>>(response));
        }

        public async Task<Response<CategoryDto>> GetCategoryWithMovieById(int id)
        {
            var response = await _unitOfWork.CategoryRepository.GetContext().Where(i => i.Id == id)
                .Include(i => i.Movies).Select(x=>new Category()
                {
                    Movies = x.Movies,
                    Id = x.Id,
                    SoftDeleted = x.SoftDeleted,
                    CreatedDate = x.CreatedDate,
                    Title = x.Title,
                    UpdateDate = x.UpdateDate
                }).AsNoTracking().FirstOrDefaultAsync();
            
            return Response<CategoryDto>.SuccessResponse(_mapper.Map<CategoryDto>(response));
        }

        public async Task<Response<NoResponse>> CreateCategory(CategoryDto category)
        {
            var categoryModel = _mapper.Map<Category>(category);
            _unitOfWork.CategoryRepository.Add(categoryModel);
            await _unitOfWork.SaveAsync();
            return Response<NoResponse>.SuccessResponse();
        }
    }
}
