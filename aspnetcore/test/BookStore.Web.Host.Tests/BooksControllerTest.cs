using BookStore.Application.Books;
using BookStore.Application.Books.Dtos;
using BookStore.Web.Host.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using Newtonsoft.Json;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace BookStore.Web.Host.Tests
{
    public class BooksControllerTest : IClassFixture<WebApplicationFactory<Startup.Startup>>
    {
        private readonly HttpClient _client;
        private List<BookDto> _books = new List<BookDto>();
        private readonly Mock<IBookAppService> _bookAppServiceMock = new Mock<IBookAppService>();

        public BooksControllerTest(WebApplicationFactory<Startup.Startup> fixture)
        {
            InitTestData();

            _client = fixture.CreateClient();
        }

        private void InitTestData()
        {
            _books.Add(new BookDto()
            {
                Id = 1,
                Title = "Title 1",
                Description = "Description 1",
                AuthorName = "AuthorName 1",
                CoverImageUrl = "CoverImageURL 1",
                Price = 0.99m,
                CreatedOn = DateTime.Now
            });

            _books.Add(new BookDto()
            {
                Id = 2,
                Title = "Title 2",
                Description = "Description 2",
                AuthorName = "AuthorName 2",
                CoverImageUrl = "CoverImageURL 2",
                Price = 10m,
                CreatedOn = DateTime.Now
            });
        }

        [Fact]
        public async Task GetById_WhenFound_ReturnOK()
        {
            //Arrange
            _bookAppServiceMock.Setup(p => p.GetByIdAsync(1)).ReturnsAsync(_books.Find(x => x.Id == 1));

            //Action
            var booksController = new BooksController(_bookAppServiceMock.Object);
            var result = await booksController.GetBook(1);

            //Assert
            result.Result.ShouldBeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public async Task GetAll_ReturnOK()
        {
            //Arrange
            _bookAppServiceMock.Setup(p => p.GetAllAsync()).ReturnsAsync(_books);

            //Action
            var booksController = new BooksController(_bookAppServiceMock.Object);
            var result = await booksController.GetAllBooks();

            //Assert
            result.Result.ShouldBeOfType(typeof(OkObjectResult));
        }

        #region REST Tests

        [Fact]
        public async Task REST_GetById_WhenFound_ReturnOK()
        {
            var response = await _client.GetAsync("/api/books/1");
            response.StatusCode.ShouldBe(HttpStatusCode.OK);

            var json = await response.Content.ReadAsStringAsync();
            var bookDto = JsonConvert.DeserializeObject<BookDto>(json);
            bookDto.Id.ShouldBe(1);
        }

        [Fact]
        public async Task REST_GetAll_ReturnOK()
        {
            var response = await _client.GetAsync("/api/books");
            response.StatusCode.ShouldBe(HttpStatusCode.OK);

            var json = await response.Content.ReadAsStringAsync();
            var bookDtos = JsonConvert.DeserializeObject<BookDto[]>(json);
            bookDtos.Length.ShouldBe(2);
        }

        #endregion
    }
}
