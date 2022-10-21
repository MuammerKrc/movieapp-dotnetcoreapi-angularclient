using CoreLayer.Dtos.CategoryDtos;
using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.IService
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategory();
        Task<CategoryDto> GetCategoryWithMovieById(int id);
        Task<CategoryDto> CreateCategory(CategoryDto category);

    }
}
