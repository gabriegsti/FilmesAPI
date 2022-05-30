using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.Endereco;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;

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
            Context.Enderecos.Add(endereco);
            Context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaEnderecosPorId), new { Id = endereco.Id }, endereco);
        }

        private object RecuperaEnderecosPorId()
        {
            throw new NotImplementedException();
        }
    }
}
