using CoreLayer.IRepositories;
using CoreLayer.IRepositories.IBaseRepositories;
using CoreLayer.Models.IdentityModels;
using DataLayer.DbContexts;
using DataLayer.Repositories;
using DataLayer.Repositories.BaseRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using CoreLayer.ConfigurationModels;
using CoreLayer.IUnitOfWorks;
using DataLayer.UnitOfWorks;
using Microsoft.AspNetCore.Identity;

namespace DataLayer
{
    public static class ServiceRegistration
    {
        public static void AddDataLayerRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MovieDbContext>(i =>
            {
                i.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), opt =>
                {
                    opt.MigrationsAssembly("DataLayer");
                });
            });

            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 5;
                opt.Password.RequiredUniqueChars = 3;
            }).AddEntityFrameworkStores<MovieDbContext>().AddDefaultTokenProviders();

            //UnitOfWorks
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //repository registered
            services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IFavoriteMoviesRepository, FavoriteMoviesRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();

        }
    }
}