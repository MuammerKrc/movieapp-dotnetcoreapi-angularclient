using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.IRepositories;
using CoreLayer.Models;
using DataLayer.DbContexts;
using DataLayer.Repositories.BaseRepositories;

namespace DataLayer.Repositories
{
    public class FavoriteMoviesRepository:BaseRepository<FavoriteMovies,int>,IFavoriteMoviesRepository
    {
        public FavoriteMoviesRepository(MovieDbContext context) : base(context)
        {
        }
    }
}
