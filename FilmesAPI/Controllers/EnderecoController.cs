using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        public AppDbContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public EnderecoController(AppDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = Mapper.Map<Endereco>(enderecoDto);
            Context.enderecos.Add(endereco);
            Context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaenderecosPorId), new { Id = endereco.Id }, endereco);
        }

        [HttpGet]
        public IEnumerable<Endereco> Recuperaenderecos()
        {
            return Context.enderecos;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaenderecosPorId(int id)
        {
            Endereco endereco = Context.enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco != null)
            {
                ReadEnderecoDto enderecoDto = Mapper.Map<ReadEnderecoDto>(endereco);

                return Ok(enderecoDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            Endereco endereco = Context.enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
            {
                return NotFound();
            }
            Mapper.Map(enderecoDto, endereco);
            Context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            Endereco endereco = Context.enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
            {
                return NotFound();
            }
            Context.Remove(endereco);
            Context.SaveChanges();
            return NoContent();
        }
    }
}
