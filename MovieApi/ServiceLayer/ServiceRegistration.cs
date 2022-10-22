using System.Collections;
using AutoMapper;
using CoreLayer.ConfigurationModels;
using CoreLayer.IServices;
using CoreLayer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Services;

namespace ServiceLayer
{
    public static class ServiceRegistration
    {
        public static void AddServiceLayerRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            // auto mapper registered
            services.AddAutoMapper(typeof(Mapper));


            // configuration
            services.Configure<TokenConfigurationModel>(configuration.GetSection("Token"));

            //service registered
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IFavoriteMoviesService, FavoriteMoviesService>();

        }
    }
}