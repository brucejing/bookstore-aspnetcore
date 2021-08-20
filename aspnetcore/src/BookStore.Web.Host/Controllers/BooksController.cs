using BookStore.Application.Books;
using BookStore.Application.Books.Dtos;
using BookStore.Web.Core.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Web.Host.Controllers
{
    /// <summary>
    /// Books API
    /// </summary>
    public class BooksController : ApiControllerBase
    {
        private readonly IBookAppService _bookAppService;

        public BooksController(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }

        /// <summary>
        /// Get all books. GET: api/books
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<BookDto>>> GetAllBooks()
        {
            var bookDtos = await _bookAppService.GetAllAsync();
            return Ok(bookDtos);
        }

        /// <summary>
        /// Get a book by ID. GET: api/books/1
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BookDto>> GetBook([FromRoute] int id)
        {
            var bookDto = await _bookAppService.GetByIdAsync(id);

            if (bookDto == null)
            {
                return NotFound();
            }

            return Ok(bookDto);
        }

        /// <summary>
        /// Create a book. POST: api/books
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BookDto>> CreateBook([FromBody] BookCreateDto bookDto)
        {
            if (string.IsNullOrWhiteSpace(bookDto.Title))
            {
                return BadRequest();
            }

            var createdBookDto = await _bookAppService.CreateAsync(new CreateBookInput() { Book = bookDto });

            return CreatedAtAction(nameof(GetBook), new { id = createdBookDto.Id }, createdBookDto);
        }

        /// <summary>
        /// Update a book. PUT: api/books/1
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateBook([FromRoute] int id, [FromBody] BookEditDto bookDto)
        {
            if (id != bookDto.Id || string.IsNullOrWhiteSpace(bookDto.Title))
            {
                return BadRequest();
            }

            if (!await _bookAppService.Exists(id))
            {
                return NotFound();
            }

            await _bookAppService.UpdateAsync(new UpdateBookInput() { Book = bookDto });

            return NoContent();
        }

        /// <summary>
        /// Delete a book. DELETE: api/books/1
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteBook([FromRoute] int id)
        {
            var book = await _bookAppService.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            await _bookAppService.DeleteAsync(id);

            return NoContent();
        }
    }
}
