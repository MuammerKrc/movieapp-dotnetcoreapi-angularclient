using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CoreLayer.IUnitOfWorks
{
    public interface IUnitOfWork
    {
        public DbContext Context { get; set; }
        public ICategoryRepository CategoryRepository { get; }
        public IFavoriteMoviesRepository FavoriteMoviesRepository { get; }
        public IMovieRepository MovieRepository { get;}
        public IJWTokenRepository JWTokenRepository { get; }
        public Task<bool> SaveChangeAsync();
        public bool SaveChange();
    }
}
