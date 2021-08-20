using System.ComponentModel.DataAnnotations;

namespace BookStore.Application.Books.Dtos
{
    public class UpdateBookInput
    {
        [Required]
        public BookEditDto Book { get; set; }
    }
}