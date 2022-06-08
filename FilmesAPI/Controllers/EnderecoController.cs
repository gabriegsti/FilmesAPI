using FilmesAPI.Data.Dtos;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilmesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private EnderecoService EnderecoService;
        public EnderecoController(EnderecoService enderecoService)
        {
            EnderecoService = enderecoService;
        }

        [HttpPost]
        public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            ReadEnderecoDto readDto = EnderecoService.AdicionaEndereco(enderecoDto);

            return CreatedAtAction(nameof(RecuperaenderecosPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public List<ReadEnderecoDto> Recuperaenderecos()
        {
            return EnderecoService.Recuperaenderecos();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaenderecosPorId(int id)
        {
            ReadEnderecoDto endereco = EnderecoService.RecuperaenderecosPorId(id);
            if (endereco != null)
            {
                return Ok(endereco);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            Result endereco = EnderecoService.AtualizaEndereco(id, enderecoDto);
            if (endereco.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            Result endereco = EnderecoService.DeletaEndereco(id);
            if (endereco.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
