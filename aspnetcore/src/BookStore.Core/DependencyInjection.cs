using BookStore.Core.Domain.Books;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterManagerServices(this IServiceCollection services)
        {
            services.AddScoped<IBookManager, BookManager>();

            return services;
        }
    }
}
