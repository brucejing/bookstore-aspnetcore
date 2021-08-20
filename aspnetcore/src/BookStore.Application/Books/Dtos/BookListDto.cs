using System;

namespace BookStore.Application.Books.Dtos
{
    /// <summary>
    /// Used when listing books.
    /// </summary>
    public class BookListDto : EntityDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string AuthorName { get; set; }

        public decimal Price { get; set; }

        public string CoverImageUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}