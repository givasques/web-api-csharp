using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Dtos;

public class UpdateCinemaDto
{
    [Required(ErrorMessage = "O campo de nome é obrigatório")]
    public String Nome { get; set; }
}
