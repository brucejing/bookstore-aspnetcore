using System.ComponentModel.DataAnnotations;

namespace BookStore.Application.Books.Dtos
{
    /// <summary>
    /// Used when updating a book.
    /// </summary>
    public class BookEditDto : EntityDto
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string AuthorName { get; set; }

        public decimal Price { get; set; }

        public string CoverImageUrl { get; set; }
    }
}