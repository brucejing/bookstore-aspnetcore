using BookStore.Core.Repositories;
using BookStore.Data.EntityFrameworkCore;
using BookStore.Data.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Data
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Register repositories when the application starts.
        /// </summary>
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddDbContext<BookStoreDbContext>(options => options.UseInMemoryDatabase("BookStore"));

            services.AddScoped(typeof(IRepository<,>), typeof(EfCoreRepository<,>));

            return services;
        }
    }
}
