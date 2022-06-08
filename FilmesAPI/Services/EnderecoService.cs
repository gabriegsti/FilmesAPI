using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Services
{
    public class EnderecoService
    {
        public AppDbContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public EnderecoService(AppDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public ReadEnderecoDto AdicionaEndereco(CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = Mapper.Map<Endereco>(enderecoDto);
            Context.enderecos.Add(endereco);
            Context.SaveChanges();
            return Mapper.Map<ReadEnderecoDto>(endereco);
        }


        public List<ReadEnderecoDto> Recuperaenderecos()
        {
            var enderecos = Context.enderecos.ToList();
            return Mapper.Map<List<ReadEnderecoDto>>(enderecos);
        }


        public ReadEnderecoDto RecuperaenderecosPorId(int id)
        {
            Endereco endereco = Context.enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco != null)
            {
                ReadEnderecoDto enderecoDto = Mapper.Map<ReadEnderecoDto>(endereco);
                return enderecoDto;
            }
            return null;
        }

        public Result AtualizaEndereco(int id, UpdateEnderecoDto enderecoDto)
        {
            Endereco endereco = Context.enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
            {
                return Result.Fail("Endereco não encontrado");
            }
            Mapper.Map(enderecoDto, endereco);
            Context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaEndereco(int id)
        {
            Endereco endereco = Context.enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
            {
                return Result.Fail("Endereco não encontrado");
            }
            Context.Remove(endereco);
            Context.SaveChanges();
            return Result.Ok();
        }
    }
}
