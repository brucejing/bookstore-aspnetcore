using System.ComponentModel.DataAnnotations;

namespace BookStore.Application.Books.Dtos
{
    public class CreateBookInput
    {
        [Required]
        public BookCreateDto Book { get; set; }
    }
}