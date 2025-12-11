using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemaController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public CinemaController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
    {
        Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
        _context.Cinemas.Add(cinema);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaCinemaPorId), new { id = cinema.Id }, cinema);
    }

    [HttpGet]
    public IEnumerable<ReadCinemaDto> RecuperaCinema([FromQuery] int? enderecoId = null)
    {
        if (enderecoId is null)
        {
            return _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.ToList());
        }
        return _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas
                    .FromSqlRaw($"SELECT Id, Nome, EnderecoId FROM cinemas WHERE EnderecoId = {enderecoId}").ToList());
            
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaCinemaPorId(int id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(f => f.Id == id);
        if (cinema is null) return NotFound();
        var cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
        return Ok(cinemaDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaCinema(int id,
        [FromBody] UpdateCinemaDto cinemaDto)
    {
        var cinema = _context.Cinemas.FirstOrDefault(filme => filme.Id == id);
        if (cinema is null) return NotFound();
        _mapper.Map(cinemaDto, cinema);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaCinema(int id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(f => f.Id == id);
        if (cinema is null) return NotFound();
        _context.Cinemas.Remove(cinema);
        _context.SaveChanges();
        return NoContent();
    }
}
