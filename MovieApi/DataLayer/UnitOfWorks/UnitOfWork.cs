using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.IRepositories;
using CoreLayer.IUnitOfWorks;
using DataLayer.DbContexts;
using DataLayer.Repositories;

namespace DataLayer.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MovieDbContext _context;

        public UnitOfWork(MovieDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        private CategoryRepository _categoryRepository;
        private MovieRepository _movieRepository;
        private FavoriteMoviesRepository _favoriteMoviesRepository;

        public ICategoryRepository CategoryRepository =>
            _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);
        public IMovieRepository MovieRepository =>
            _movieRepository = _movieRepository ?? new MovieRepository(_context);
        public IFavoriteMoviesRepository FavoriteMoviesRepository =>
            _favoriteMoviesRepository ?? new FavoriteMoviesRepository(_context);
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
