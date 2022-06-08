using FilmesAPI.Data.Dtos;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilmesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController : ControllerBase
    {

        public CinemaService CinemaService { get; set; }
        public CinemaController(CinemaService cinemaService)
        {
            CinemaService = cinemaService;
        }


        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            ReadCinemaDto readDto = CinemaService.AdicionaCinema(cinemaDto);

            return CreatedAtAction(nameof(RecuperacinemasPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult Recuperacinemas([FromQuery] string nomeDoFilme)
        {
            List<ReadCinemaDto> readDto = CinemaService.RecuperaCinemas(nomeDoFilme);
            if (readDto == null)
                return NotFound();

            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperacinemasPorId(int id)
        {
            ReadCinemaDto cinemaDto = CinemaService.RecuperaCinemasPorId(id);
            if (cinemaDto != null)
            {
                return Ok(cinemaDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Result resultado = CinemaService.AtualizaCinema(id, cinemaDto);
            if (resultado.IsFailed)
                return NotFound();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            Result resultado = CinemaService.DeletaCinema(id);
            if (resultado.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
