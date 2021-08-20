using AutoMapper;
using BookStore.Application.Books;
using BookStore.Application.Infrastructure.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Application
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Register automapper configuration when the application starts.
        /// </summary>
        public static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
        {
            //create AutoMapper configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApplicationAutoMapperProfile>();
            });

            //register
            AutoMapperConfiguration.Init(config);

            //register AutoMapper
            services.AddSingleton(AutoMapperConfiguration.Mapper);

            return services;
        }

        /// <summary>
        /// Register application services when the application starts.
        /// </summary>
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<Infrastructure.Mapper.IObjectMapper, AutoMapperObjectMapper>();

            services.AddScoped<IBookAppService, BookAppService>();

            return services;
        }
    }
}
