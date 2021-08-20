using System;

namespace BookStore.Core.Domain.Books
{
    /// <summary>
    /// Represents a book entity.
    /// </summary>
    public class Book : Entity<int>
    {
        #region Constants

        public const int TitleMaxLength = 100;

        #endregion

        public Book()
        {
            this.CreatedOn = DateTime.Now;
        }

        #region Properties

        /// <summary>
        /// Gets or sets the title. Required. Max length is <see cref="TitleMaxLength"/>.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the author name.
        /// </summary>
        public string AuthorName { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the cover image URL.
        /// </summary>
        public string CoverImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the creation time.
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the last update time.
        /// </summary>
        public DateTime? UpdatedOn { get; set; }

        #endregion
    }
}
