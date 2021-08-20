using AutoMapper;
using BookStore.Application.Books.Dtos;
using BookStore.Core.Domain.Books;

namespace BookStore.Application.Infrastructure.Mapper
{
    /// <summary>
    /// Configure the mapping between entities and DTOs for automapper.
    /// </summary>
    public class ApplicationAutoMapperProfile : Profile
    {
        public ApplicationAutoMapperProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<Book, BookListDto>();
            CreateMap<BookCreateDto, Book>();
            CreateMap<BookEditDto, Book>();
        }
    }
}
