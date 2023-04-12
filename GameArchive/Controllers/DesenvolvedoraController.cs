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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DesenvolvedoraModel>>> BuscarTodas()
        {
            var desenvolvedoras = await _desenvolvedoraRepositorio.BuscarTodas();

            return Ok(desenvolvedoras);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DesenvolvedoraModel>> BuscarPorId(int id)
        {
            var desenvolvedora = await _desenvolvedoraRepositorio.BuscarPorId(id);
            return Ok(desenvolvedora);
        }

        [HttpGet("BuscarNome/{nome}")]
        public async Task<ActionResult<DesenvolvedoraModel>> BuscarNome(string nome)
        {
            var jogos = await _desenvolvedoraRepositorio.BuscarPorNome(nome);
            return Ok(jogos);
        }

        [HttpPost]
        public async Task<ActionResult<DesenvolvedoraModel>> Cadastrar([FromBody] DesenvolvedoraModel desenvolvedoraModel)
        {
            var desenvolvedora = await _desenvolvedoraRepositorio.Adicionar(desenvolvedoraModel);

            return Ok(desenvolvedora);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DesenvolvedoraModel>> Atualizar([FromBody] DesenvolvedoraModel desenvolvedoraModel, int id)
        {
            desenvolvedoraModel.Id = id;
            var desenvolvedora = await _desenvolvedoraRepositorio.Atualizar(desenvolvedoraModel, id);
            return Ok(desenvolvedora);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DesenvolvedoraModel>> Apagar(int id)
        {
            var apagada = await _desenvolvedoraRepositorio.Apagar(id);

            return Ok(apagada);
        }
    }
}
