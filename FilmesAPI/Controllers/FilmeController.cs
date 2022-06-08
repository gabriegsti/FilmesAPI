using FilmesAPI.Data.Dtos;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmeController : ControllerBase
    {
        public FilmeService FilmeService;

        public FilmeController(FilmeService filmeService)
        {
            FilmeService = filmeService;
        }


        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            ReadFilmeDto readDto = FilmeService.AdicionaFilme(filmeDto);

            return CreatedAtAction(nameof(RecuperafilmesPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult Recuperafilmes([FromQuery] int? classificacaoEtaria = null)
        {
            List<ReadFilmeDto> readDto = FilmeService.RecuperaFilmes(classificacaoEtaria);
            if (readDto != null)
            {
                return Ok(readDto);
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperafilmesPorId(int id)
        {
            ReadFilmeDto readDto = FilmeService.RecuperaFilmesPorId(id);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Result resultado = FilmeService.AtualizaFilme(id, filmeDto);
            if (resultado.IsFailed) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Result resultado = FilmeService.DeletaFilme(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
