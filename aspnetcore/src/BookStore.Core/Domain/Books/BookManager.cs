using BookStore.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Core.Domain.Books
{
    /// <summary>
    /// Manages the business of the book domain. 
    /// </summary>
    public class BookManager : IBookManager
    {
        private readonly IRepository<Book, int> _bookRepository;

        public BookManager(IRepository<Book, int> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        /// <summary>
        /// Gets a book by the given ID.
        /// </summary>
        /// <param name="id">Book ID</param>
        /// <param name="asNoTracking">Indicates if the entity should track its changes.
        /// If true, no change track to improve the performance.
        /// If false, track any changes.
        /// Defaults to true.</param>
        /// <returns>Book entity</returns>
        public async Task<Book> GetByIdAsync(int id, bool asNoTracking = true)
        {
            Book book;

            if (asNoTracking)
            {
                book = _bookRepository.TableNoTracking.FirstOrDefault(x => x.Id == id);
            }
            else
            {
                book = await _bookRepository.GetByIdAsync(id);
            }

            return book;
        }

        /// <summary>
        /// Gets all books.
        /// </summary>
        /// <param name="asNoTracking">Indicates if the entity should track its changes.
        /// If true, no change track to improve the performance.
        /// If false, track any changes.
        /// Defaults to true.</param>
        /// <returns>A list of book entity</returns>
        public async Task<List<Book>> GetAllAsync(bool asNoTracking = true)
        {
            List<Book> books;

            if (asNoTracking)
            {
                books = _bookRepository.TableNoTracking.ToList();
            }
            else
            {
                books = await _bookRepository.GetAllAsync();
            }

            return books;
        }

        /// <summary>
        /// Creates a book.
        /// </summary>
        /// <param name="book">The book entity to be created.</param>
        /// <returns>The created book</returns>
        public async Task<Book> CreateAsync(Book book)
        {
            book.CreatedOn = DateTime.Now;
            var createdBook = await _bookRepository.InsertAsync(book);
            return createdBook;
        }

        /// <summary>
        /// Updates a book.
        /// </summary>
        /// <param name="book">The book to be updated.</param>
        public async Task UpdateAsync(Book book)
        {
            book.UpdatedOn = DateTime.Now;
            await _bookRepository.UpdateAsync(book);
        }

        /// <summary>
        /// Hard deletes a book.
        /// </summary>
        /// <param name="book">The book to be deleted.</param>
        public async Task DeleteAsync(Book book)
        {
            await _bookRepository.DeleteAsync(book);
        }
    }
}
