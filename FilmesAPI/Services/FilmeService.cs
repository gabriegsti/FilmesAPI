using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Services
{
    public class FilmeService
    {
        public AppDbContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public ReadFilmeDto AdicionaFilme(CreateFilmeDto filmeDto)
        {
            Filme filme = Mapper.Map<Filme>(filmeDto);
            Context.filmes.Add(filme);
            Context.SaveChanges();
            return Mapper.Map<ReadFilmeDto>(filme);
        }

        public List<ReadFilmeDto> RecuperaFilmes(int? classificacaoEtaria)
        {
            List<Filme> filmes;
            if (classificacaoEtaria == null)
            {
                filmes = Context.filmes.ToList();

            }
            else
            {
                filmes = Context.filmes.Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria).ToList();
            }

            if (filmes != null)
            {
                List<ReadFilmeDto> readDto = Mapper.Map<List<ReadFilmeDto>>(filmes);
                return readDto;
            }

            return null;
        }

        public ReadFilmeDto RecuperaFilmesPorId(int id)
        {
            Filme filme = Context.filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
            {
                ReadFilmeDto filmeDto = Mapper.Map<ReadFilmeDto>(filme);

                return filmeDto;
            }
            return null;
        }

        internal Result AtualizaFilme(int id, UpdateFilmeDto filmeDto)
        {
            Filme filme = Context.filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return Result.Fail("Filme não encontrado");
            }
            Mapper.Map(filmeDto, filme);
            Context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaFilme(int id)
        {
            Filme filme = Context.filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return Result.Fail("Filme não encontrado");
            }
            Context.Remove(filme);
            Context.SaveChanges();
            return Result.Ok();
        }
    }
}
