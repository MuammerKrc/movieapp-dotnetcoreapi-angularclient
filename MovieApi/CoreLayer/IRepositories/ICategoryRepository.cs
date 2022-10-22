using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Dtos.CategoryDtos;
using CoreLayer.IRepositories.IBaseRepositories;
using CoreLayer.Models;

namespace CoreLayer.IRepositories
{
    public interface ICategoryRepository : IBaseRepository<Category, int>
    {
        


    }
}
