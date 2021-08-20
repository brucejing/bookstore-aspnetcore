using BookStore.Application;
using BookStore.Core;
using BookStore.Core.Domain.Books;
using BookStore.Data;
using BookStore.Data.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookStore.Web.Host.Startup
{
    public class Startup
    {
        private const string _defaultCorsPolicyName = "localhost";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                    options.JsonSerializerOptions.WriteIndented = true;
                });
            services.AddCors(options =>
            {
                options.AddPolicy(_defaultCorsPolicyName,
                    builder =>
                    {
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                        builder.AllowAnyOrigin();
                    });
            });
            services.AddSwaggerDocument();

            services.RegisterRepositories();
            services.RegisterManagerServices();
            services.RegisterAutoMapper();
            services.RegisterApplicationServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(_defaultCorsPolicyName);

            app.UseStaticFiles();

            app.UseOpenApi();
            app.UseSwaggerUi3(settings =>
            {
                settings.TransformToExternalPath = (internalUiRoute, request) =>
                {
                    if (internalUiRoute.StartsWith("/") && !internalUiRoute.StartsWith(request.PathBase))
                    {
                        return request.PathBase + internalUiRoute;
                    }
                    return internalUiRoute;
                };
            });

            app.UseRouting();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            InitializeTestData(app);
        }

        private static void InitializeTestData(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<BookStoreDbContext>();

            context.Books.Add(new Book()
            {
                Title = "People We Meet on Vacation",
                Description = "THE #1 NEW YORK TIMES BESTSELLER! A TONIGHT SHOW STARRING JIMMY FALLON SUMMER READS NOMINEE! Named a Most Anticipated Book of 2021 by Newsweek ∙ Oprah Magazine ∙ The Skimm ∙ Marie Claire ∙ Parade ∙ The Wall Street Journal ∙ Chicago Tribune ∙ PopSugar ∙ BookPage ∙ BookBub ∙ Betches ∙ SheReads ∙ Good Housekeeping ∙ BuzzFeed ∙ Business Insider ∙ Real Simple ∙ Frolic ∙ and more!",
                AuthorName = " Emily Henry",
                Price = 14.36m,
                CoverImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51wHHB9OkwL._SX331_BO1,204,203,200_.jpg"
            });
            context.Books.Add(new Book()
            {
                Title = "Time for School, Little Blue Truck",
                Description = "Little Blue Truck and his good friend Toad are excited to meet a bright yellow school bus on the road. They see all the little animals lined up in the school bus’s many windows, and Blue wishes he could be a school bus too. What a fun job—but much too big for a little pickup like Blue. Or is it? When somebody misses the bus, it’s up to Blue to get his friend to school on time. Beep! Beep! Vroom!",
                AuthorName = "Alice Schertle and Jill McElmurry",
                Price = 14.99m,
                CoverImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51E+TsPtBJS._SY411_BO1,204,203,200_.jpg"
            });
            context.SaveChanges();
        }
    }
}
