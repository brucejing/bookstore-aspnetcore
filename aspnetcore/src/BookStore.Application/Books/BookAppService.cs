using BookStore.Application.Books.Dtos;
using BookStore.Application.Infrastructure.Mapper;
using BookStore.Core.Domain.Books;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Application.Books
{
    public class BookAppService : IBookAppService
    {
        private readonly IObjectMapper _objectMapper;
        private readonly IBookManager _bookManager;

        public BookAppService(IObjectMapper objectMapper,
            IBookManager bookManager)
        {
            _objectMapper = objectMapper;
            _bookManager = bookManager;
        }

        public async Task<IList<BookDto>> GetAllAsync()
        {
            var books = await _bookManager.GetAllAsync();
            var bookListDtos = _objectMapper.Map<List<BookDto>>(books);
            return new List<BookDto>(bookListDtos);
        }

        public async Task<BookDto> GetByIdAsync(int bookId)
        {
            var book = await _bookManager.GetByIdAsync(bookId);
            var bookDto = _objectMapper.Map<BookDto>(book);
            return bookDto;
        }

        public async Task<bool> Exists(int bookId)
        {
            var book = await _bookManager.GetByIdAsync(bookId);
            return book != null;
        }

        public async Task<BookDto> CreateAsync(CreateBookInput input)
        {
            var book = _objectMapper.Map<Book>(input.Book);
            var newBook = await _bookManager.CreateAsync(book);
            var newBookDto = _objectMapper.Map<BookDto>(newBook);
            return newBookDto;
        }

        public async Task UpdateAsync(UpdateBookInput input)
        {
            var book = _objectMapper.Map<Book>(input.Book);
            await _bookManager.UpdateAsync(book);
        }

        public async Task DeleteAsync(int bookId)
        {
            var book = await _bookManager.GetByIdAsync(bookId);
            await _bookManager.DeleteAsync(book);
        }
    }
}
