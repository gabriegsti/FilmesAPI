using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GerenteController : ControllerBase
    {
        private AppDbContext Context;
        private IMapper Mapper;

        public GerenteController(AppDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        [HttpPost]
        public IActionResult AdicionaGerente([FromBody] CreateGerenteDto dto)
        {
            Gerente gerente = Mapper.Map<Gerente>(dto);
            Context.gerentes.Add(gerente);
            Context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaGerentesPorId), new { Id = gerente.Id }, gerente);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGerentesPorId(int id)
        {
            Gerente gerente = Context.gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente != null)
            {
                ReadGerenteDto filmeDto = Mapper.Map<ReadGerenteDto>(gerente);

                return Ok(filmeDto);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaGerente(int id)
        {
            Gerente gerente = Context.gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente == null)
            {
                return NotFound();
            }
            Context.Remove(gerente);
            Context.SaveChanges();
            return NoContent();
        }
    }
}
