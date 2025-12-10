using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Dtos;

public class CreateCinemaDto
{
    [Required(ErrorMessage = "O campo de nome é obrigatório")]
    public String Nome { get; set; }
    public int EnderecoId { get; set; }
}
