using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Exceptions;
using CoreLayer.IRepositories.IBaseRepositories;
using CoreLayer.Models.BaseModels;
using DataLayer.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DataLayer.Repositories.BaseRepositories
{
    public class BaseRepository<TModel, TKey> : IBaseRepository<TModel, TKey> where TModel : BaseModel<TKey>
    {
        public readonly MovieDbContext _context;

        public BaseRepository(MovieDbContext context)
        {
            _context = context;
        }

        public DbSet<TModel> _entities => _context.Set<TModel>();

        public void Add(TModel model)
        {
            _context.Entry<TModel>(model).State = EntityState.Added;
        }

        public int GetCount()
        {
            return _entities.Count();
        }

        public void AddAll(IEnumerable<TModel> models)
        {
            models.ToList().ForEach(i => _context.Entry<TModel>(i).State = EntityState.Added);
        }

        public void Update(TModel model)
        {
            _context.Entry<TModel>(model).State = EntityState.Modified;
        }

        public async Task Delete(TKey id)
        {
            var result = await GetByIdAsync(id, true);
            _context.Entry<TModel>(result).State = EntityState.Deleted;
        }

        public async Task SoftDelete(TKey id)
        {
            var result = await GetByIdAsync(id, true);
            result.SoftDeleted = true;
        }

        public async Task<IEnumerable<TModel>> GetAllAsync(bool tracking = false)
        {
            if (tracking)
                return await _entities.AsNoTracking().ToListAsync();
            return await _entities.ToListAsync();
        }

        public async Task<TModel> GetByIdAsync(TKey id, bool tracking = false)
        {
            var querableRequest = _entities.Where(i => i.Id.Equals(id));
            if (!tracking)
                querableRequest = querableRequest.AsNoTracking();

            var response = await querableRequest.FirstOrDefaultAsync();
            if (response == null)
                throw new NotFoundEntityException();
            return response;

        }

        public IQueryable<TModel> GetWhereAsync(Expression<Func<TModel, bool>> method)
        {
           return _entities.Where(method).AsQueryable();
            
        }

        public async Task<TModel> GetSingleAsync(Expression<Func<TModel, bool>> method, bool tracking = false)
        {
            var querableRequest = _entities.Where(method);
            if (!tracking)
                querableRequest = querableRequest.AsNoTracking();
            return await querableRequest.FirstOrDefaultAsync();
        }

        public DbSet<TModel> GetContext()
        {
            return _entities;
        }
    }
}
