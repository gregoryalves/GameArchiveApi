using GameArchive.Models;
using GameArchive.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameArchive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlataformaController : ControllerBase
    {
        private readonly IPlataformaRepositorio _plataformaRepositorio;

        public PlataformaController(IPlataformaRepositorio plataformaRepositorio)
        {
            _plataformaRepositorio = plataformaRepositorio;
        }

        [HttpGet("BuscarTodos")]
        public async Task<ActionResult<IEnumerable<PlataformaModel>>> BuscarTodos()
        {
            var plataformas = await _plataformaRepositorio.BuscarTodas();

            return Ok(plataformas);
        }

        [HttpGet("BuscarPorId/{id}")]
        public async Task<ActionResult<PlataformaModel>> BuscarPorId(int id)
        {
            var plataforma = await _plataformaRepositorio.BuscarPorId(id);
            return Ok(plataforma);
        }

        [HttpGet("BuscarPorNome/{nome}")]
        public async Task<ActionResult<PlataformaModel>> BuscarPorNome(string nome)
        {
            var jogos = await _plataformaRepositorio.BuscarPorNome(nome);
            return Ok(jogos);
        }

        [HttpPost("Cadastrar")]
        public async Task<ActionResult<PlataformaModel>> Cadastrar([FromBody] PlataformaModel plataformaModel)
        {
            var plataforma = await _plataformaRepositorio.Adicionar(plataformaModel);

            return Ok(plataforma);
        }

        [HttpPut("Atualizar/{id}")]
        public async Task<ActionResult<PlataformaModel>> Atualizar([FromBody] PlataformaModel plataformaModel, int id)
        {
            plataformaModel.Id = id;
            var plataforma = await _plataformaRepositorio.Atualizar(plataformaModel, id);
            return Ok(plataforma);
        }

        [HttpDelete("Apagar/{id}")]
        public async Task<ActionResult<PlataformaModel>> Apagar(int id)
        {
            var apagada = await _plataformaRepositorio.Apagar(id);

            return Ok(apagada);
        }
    }
}
