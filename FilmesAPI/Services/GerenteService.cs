using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;
using System.Linq;

namespace FilmesAPI.Services
{
    public class GerenteService
    {
        private AppDbContext Context;
        private IMapper Mapper;

        public GerenteService(AppDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public ReadGerenteDto AdicionaGerente(CreateGerenteDto createGerenteDto)
        {
            Gerente gerente = Mapper.Map<Gerente>(createGerenteDto);
            Context.gerentes.Add(gerente);
            Context.SaveChanges();
            return Mapper.Map<ReadGerenteDto>(gerente);
        }

        public ReadGerenteDto RecuperaGerentePorId(int id)
        {
            Gerente gerente = Context.gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente != null)
            {
                ReadGerenteDto gerenteDto = Mapper.Map<ReadGerenteDto>(gerente);

                return gerenteDto;
            }
            return null;
        }

        public Result AtualizaGerentePorId(int id, UpdateGerenteDto updateGerenteDto)
        {
            Gerente gerente = Context.gerentes.FirstOrDefault(gerente => gerente.Id == id);

            if (gerente == null)
                return Result.Fail("Gerente não encontrado");
            return Result.Ok();
        }


        public Result DeletaGerente(int id)
        {
            Gerente gerente = Context.gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente == null)
            {
                return Result.Fail("Gerente não encontrado");
            }
            Context.Remove(gerente);
            Context.SaveChanges();
            return Result.Ok();
        }
    }
}
