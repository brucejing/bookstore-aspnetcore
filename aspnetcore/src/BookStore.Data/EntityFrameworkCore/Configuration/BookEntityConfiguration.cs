using BookStore.Core.Domain.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Data.EntityFrameworkCore.Configuration
{
    /// <summary>
    /// Configure book entity database schema.
    /// </summary>
    public class BookEntityConfiguration : EntityConfiguration<Book, int>
    {
        public override void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id).UseIdentityColumn();
            builder.Property(b => b.Title).HasMaxLength(Book.TitleMaxLength).IsRequired();
            builder.Property(b => b.UpdatedOn).IsRequired(false);

            base.Configure(builder);
        }
    }
}
