using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceLayer
{
    public static class ServiceRegistration
    {
        public static void AddServiceLayerRegistration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Mapper));
        }
    }
}