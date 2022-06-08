using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Data.Dtos.Sessao;
using FilmesAPI.Models;
using System.Linq;

namespace FilmesAPI.Services
{
    public class SessaoService
    {
        private AppDbContext Context { get; set; }
        private IMapper Mapper { get; set; }
        public SessaoService(AppDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public ReadSessaoDto AdicionaSessao(CreateSessaoDto dto)
        {
            Sessao sessao = Mapper.Map<Sessao>(dto);
            Context.Sessoes.Add(sessao);
            Context.SaveChanges();
            return Mapper.Map<ReadSessaoDto>(sessao);
        }

        internal ReadSessaoDto RecuperaSessoesPorId(int id)
        {
            Sessao sessao = Context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao != null)
            {
                ReadSessaoDto sessaoDto = Mapper.Map<ReadSessaoDto>(sessao);

                return sessaoDto;
            }
            return null;
        }
    }
}
