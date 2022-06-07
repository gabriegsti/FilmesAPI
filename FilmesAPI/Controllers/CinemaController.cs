using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController : ControllerBase
    {

        private AppDbContext _context;
        private IMapper _mapper;

        public CinemaController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.cinemas.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperacinemasPorId), new { Id = cinema.Id }, cinema);
        }

        [HttpGet]
        public IActionResult Recuperacinemas([FromQuery] string nomeDoFilme)
        {
            List<Cinema> cinemas = _context.cinemas.ToList();
            if (cinemas == null)
                return NotFound();

            if (!string.IsNullOrEmpty(nomeDoFilme))
            {
                var query = from cinema in cinemas
                            where cinema.Sessoes.Any(sessao => sessao.Filme.Titulo == nomeDoFilme)
                            select cinema;
                cinemas = query.ToList();
            }
            List<ReadCinemaDto> readDto = _mapper.Map<List<ReadCinemaDto>>(cinemas);
            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperacinemasPorId(int id)
        {
            Cinema cinema = _context.cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema != null)
            {
                ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
                return Ok(cinemaDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Cinema cinema = _context.cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return NotFound();
            }
            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            Cinema cinema = _context.cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return NotFound();
            }
            _context.Remove(cinema);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
