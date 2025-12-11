using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Dtos;

public class ReadCinemaDto
{
    public int Id { get; set; }
    public String Nome { get; set; }
    public ReadEnderecoDto Endereco { get; set; }
    public ICollection<ReadSessaoDto> Sessoes { get; set; }
}
