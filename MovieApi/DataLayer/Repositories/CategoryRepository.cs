using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.IRepositories;
using CoreLayer.IRepositories.IBaseRepositories;
using CoreLayer.IServices;
using CoreLayer.Models;
using DataLayer.DbContexts;
using DataLayer.Repositories.BaseRepositories;

namespace DataLayer.Repositories
{
    public class CategoryRepository:BaseRepository<Category,int>,ICategoryRepository
    {
        public CategoryRepository(MovieDbContext context) : base(context)
        {
        }
    }
}
