using GameArchive.Models;
using GameArchive.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameArchive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesenvolvedoraController : ControllerBase
    {
        private readonly IDesenvolvedoraRepositorio _desenvolvedoraRepositorio;

        public DesenvolvedoraController(IDesenvolvedoraRepositorio desenvolvedoraCRepositorio)
        {
            _desenvolvedoraRepositorio = desenvolvedoraCRepositorio;
        }

        [HttpGet("BuscarTodas")]
        public async Task<ActionResult<IEnumerable<DesenvolvedoraModel>>> BuscarTodas()
        {
            var desenvolvedoras = await _desenvolvedoraRepositorio.BuscarTodas();

            return Ok(desenvolvedoras);
        }

        [HttpGet("BuscarPorId/{id}")]
        public async Task<ActionResult<DesenvolvedoraModel>> BuscarPorId(int id)
        {
            var desenvolvedora = await _desenvolvedoraRepositorio.BuscarPorId(id);
            return Ok(desenvolvedora);
        }

        [HttpGet("BuscarPorNome/{nome}")]
        public async Task<ActionResult<DesenvolvedoraModel>> BuscarPorNome(string nome)
        {
            var jogos = await _desenvolvedoraRepositorio.BuscarPorNome(nome);
            return Ok(jogos);
        }

        [HttpPost("Cadastrar")]
        public async Task<ActionResult<DesenvolvedoraModel>> Cadastrar([FromBody] DesenvolvedoraModel desenvolvedoraModel)
        {
            var desenvolvedora = await _desenvolvedoraRepositorio.Adicionar(desenvolvedoraModel);

            return Ok(desenvolvedora);
        }

        [HttpPut("Atualizar/{id}")]
        public async Task<ActionResult<DesenvolvedoraModel>> Atualizar([FromBody] DesenvolvedoraModel desenvolvedoraModel, int id)
        {
            desenvolvedoraModel.Id = id;
            var desenvolvedora = await _desenvolvedoraRepositorio.Atualizar(desenvolvedoraModel, id);
            return Ok(desenvolvedora);
        }

        [HttpDelete("Apagar/{id}")]
        public async Task<ActionResult<DesenvolvedoraModel>> Apagar(int id)
        {
            var apagada = await _desenvolvedoraRepositorio.Apagar(id);

            return Ok(apagada);
        }
    }
}
