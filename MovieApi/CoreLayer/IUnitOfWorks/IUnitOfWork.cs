using CoreLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.IUnitOfWorks
{
    public  interface IUnitOfWork:IDisposable
    {
        public ICategoryRepository CategoryRepository { get; }
        public IMovieRepository MovieRepository { get; }
        public IFavoriteMoviesRepository FavoriteMoviesRepository { get; }
        Task<int> SaveAsync();
    }
}
