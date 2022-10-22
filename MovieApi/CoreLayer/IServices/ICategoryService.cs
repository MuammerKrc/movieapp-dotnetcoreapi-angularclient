using CoreLayer.Dtos.CategoryDtos;
using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Dtos;

namespace CoreLayer.IServices
{
    public interface ICategoryService
    {
        Task<Response<IEnumerable<CategoryDto>>> GetAllCategory();
        Task<Response<CategoryDto>> GetCategoryWithMovieById(int id);
        Task<Response<NoResponse>> CreateCategory(CategoryDto category);
    }
}
