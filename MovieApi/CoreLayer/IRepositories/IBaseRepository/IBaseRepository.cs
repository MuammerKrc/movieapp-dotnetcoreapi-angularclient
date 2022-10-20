using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Models.BaseModels;
using CoreLayer.Models.IdentityModels;
using Microsoft.EntityFrameworkCore;

namespace CoreLayer.IRepositories.IBaseRepository
{
    public interface IBaseRepository<TModel, TKey> where TModel : BaseModel<TKey>
    {
        DbSet<TModel> _context { get; }
        void Add(TModel model);
        void AddAll(IEnumerable<TModel> models);
        void Update(TModel model);
        void Delete(TKey id);
        void SoftDelete(TKey id);
        Task<IEnumerable<TModel>> GetAllAsync(bool tracking = false);
        Task<TModel> GetByIdAsync(TKey id, bool tracking = false);
        Task<IQueryable<TModel>> GetWhereAsync(Expression<Func<TModel, bool>> method, bool tracking = false);
        Task<TModel> GetSingleAsync(Expression<Func<TModel, bool>> method, bool tracking = false);
        Task<DbSet<TModel>> GetContext();
    }
}
