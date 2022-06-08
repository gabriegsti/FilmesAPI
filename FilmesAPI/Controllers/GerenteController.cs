using FilmesAPI.Data.Dtos;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GerenteController : ControllerBase
    {
        private GerenteService GerenteService;
        public GerenteController(GerenteService gerenteService)
        {
            GerenteService = gerenteService;
        }
        [HttpPost]
        public IActionResult AdicionaGerente([FromBody] CreateGerenteDto dto)
        {
            ReadGerenteDto gerente = GerenteService.AdicionaGerente(dto);

            return CreatedAtAction(nameof(RecuperaGerentesPorId), new { Id = gerente.Id }, gerente);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGerentesPorId(int id)
        {

            ReadGerenteDto gerente = GerenteService.RecuperaGerentePorId(id);
            if (gerente != null)
            {
                return Ok(gerente);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaGerentePorId(int id, UpdateGerenteDto updateGerenteDto)
        {
            Result resultado = GerenteService.AtualizaGerentePorId(id, updateGerenteDto);

            if (resultado.IsFailed)
                return NotFound();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaGerente(int id)
        {
            Result gerente = GerenteService.DeletaGerente(id);
            if (gerente.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
