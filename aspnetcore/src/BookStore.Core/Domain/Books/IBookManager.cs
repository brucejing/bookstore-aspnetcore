using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Core.Domain.Books
{
    public interface IBookManager
    {
        /// <summary>
        /// Gets a book by the given ID.
        /// </summary>
        /// <param name="id">Book ID</param>
        /// <param name="asNoTracking">Indicates if the entity should track its changes.
        /// If true, no change track to improve the performance.
        /// If false, track any changes.
        /// Defaults to true.</param>
        /// <returns>Book entity</returns>
        Task<Book> GetByIdAsync(int id, bool asNoTracking = true);

        /// <summary>
        /// Gets all books.
        /// </summary>
        /// <param name="asNoTracking">Indicates if the entity should track its changes.
        /// If true, no change track to improve the performance.
        /// If false, track any changes.
        /// Defaults to true.</param>
        /// <returns>A list of book entity</returns>
        Task<List<Book>> GetAllAsync(bool asNoTracking = true);

        /// <summary>
        /// Creates a book.
        /// </summary>
        /// <param name="book">The book entity to be created.</param>
        /// <returns>The created book</returns>
        Task<Book> CreateAsync(Book book);

        /// <summary>
        /// Updates a book.
        /// </summary>
        /// <param name="book">The book to be updated.</param>
        Task UpdateAsync(Book book);

        /// <summary>
        /// Hard deletes a book.
        /// </summary>
        /// <param name="book">The book to be deleted.</param>
        Task DeleteAsync(Book book);
    }
}
