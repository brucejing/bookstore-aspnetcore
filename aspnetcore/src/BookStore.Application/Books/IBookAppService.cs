using BookStore.Application.Books.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Application.Books
{
    /// <summary>
    /// Represents the application services of books.
    /// </summary>
    public interface IBookAppService
    {
        /// <summary>
        /// Gets all books.
        /// </summary>
        /// <returns>A list of <see cref="BookDto"/></returns>
        Task<IList<BookDto>> GetAllAsync();

        /// <summary>
        /// Gets a book by the given ID.
        /// </summary>
        /// <param name="bookId">Book ID</param>
        /// <returns>A <see cref="BookDto"/></returns>
        Task<BookDto> GetByIdAsync(int bookId);

        /// <summary>
        /// Checks if the specified book exists by its ID.
        /// </summary>
        /// <param name="bookId">Book ID</param>
        /// <returns>True if the book exists; otherwise, false.</returns>
        Task<bool> Exists(int bookId);

        /// <summary>
        /// Creates a book.
        /// </summary>
        /// <returns>The created <see cref="BookDto"/></returns>
        Task<BookDto> CreateAsync(CreateBookInput input);

        /// <summary>
        /// Updates a book.
        /// </summary>
        Task UpdateAsync(UpdateBookInput input);

        /// <summary>
        /// Hard deletes a book.
        /// </summary>
        /// <param name="bookId">Book ID</param>
        Task DeleteAsync(int bookId);
    }
}
