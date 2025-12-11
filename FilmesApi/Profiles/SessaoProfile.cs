using AutoMapper;
using FilmesApi.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Profiles;

public class SessaoProfile : Profile
{
    public SessaoProfile()
    {
        CreateMap<CreateSessaoDto, Sessao>();
        CreateMap<Sessao, ReadSessaoDto>()
            .ForMember(sessaoDto => sessaoDto.ReadFilmeDto, 
            opt => opt.MapFrom(sessao => sessao.Filme));
    }
}
