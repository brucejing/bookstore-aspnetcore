using BookStore.Core.Domain.Books;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BookStore.Data.EntityFrameworkCore
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext()
        {
        }

        public BookStoreDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        public virtual DbSet<Book> Books { get; set; }
    }
}
