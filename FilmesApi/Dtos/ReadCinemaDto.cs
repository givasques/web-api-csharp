using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Dtos;

public class ReadCinemaDto
{
    public int Id { get; set; }
    public String Nome { get; set; }
    public ReadEnderecoDto ReadEnderecoDto { get; set; }
}
