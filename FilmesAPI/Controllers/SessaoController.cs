using FilmesAPI.Data.Dtos;
using FilmesAPI.Data.Dtos.Sessao;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessaoController : ControllerBase
    {
        private SessaoService SessaoService;
        public SessaoController(SessaoService sessaoService)
        {
            SessaoService = sessaoService;
        }

        [HttpPost]
        public IActionResult AdicionaSessao(CreateSessaoDto dto)
        {
            ReadSessaoDto sessao = SessaoService.AdicionaSessao(dto);

            return CreatedAtAction(nameof(RecuperaSessoesPorId), new { Id = sessao.Id }, sessao);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessoesPorId(int id)
        {
            ReadSessaoDto sessao = SessaoService.RecuperaSessoesPorId(id);
            if (sessao != null)
            {
                return Ok(sessao);
            }
            return NotFound();
        }
    }
}
