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
    public class MovieRepository : BaseRepository<Movie, int>, IMovieRepository
    {
        public MovieRepository(MovieDbContext context) : base(context)
        {

        }
    }
}
