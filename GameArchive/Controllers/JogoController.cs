using GameArchive.Models;
using GameArchive.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameArchive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        private readonly IJogoRepositorio _jogoRepositorio;

        public JogoController(IJogoRepositorio jogoRepositorio)
        {
            _jogoRepositorio = jogoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JogoModel>>> BuscarTodos()
        {
            var jogos = await _jogoRepositorio.BuscarTodos();

            return Ok(jogos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JogoModel>> BuscarPorId(int id)
        {
            var jogo = await _jogoRepositorio.BuscarPorId(id);
            return Ok(jogo);
        }

        [HttpPost]
        public async Task<ActionResult<JogoModel>> Cadastrar([FromBody] JogoModel jogoModel)
        {
            var jogo = await _jogoRepositorio.Adicionar(jogoModel);

            return Ok(jogo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<JogoModel>> Atualizar([FromBody] JogoModel jogoModel, int id)
        {
            jogoModel.Id = id;
            var jogo = await _jogoRepositorio.Atualizar(jogoModel, id);
            return Ok(jogo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<JogoModel>> Apagar(int id)
        {
            var apagado = await _jogoRepositorio.Apagar(id);

            return Ok(apagado);
        }
    }
}
