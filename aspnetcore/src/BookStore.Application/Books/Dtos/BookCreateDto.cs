using System.ComponentModel.DataAnnotations;

namespace BookStore.Application.Books.Dtos
{
    /// <summary>
    /// Used when creating a book.
    /// </summary>
    public class BookCreateDto
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string AuthorName { get; set; }

        public decimal Price { get; set; }

        public string CoverImageUrl { get; set; }
    }
}