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

        [HttpGet("BuscarTodos")]
        public async Task<ActionResult<IEnumerable<JogoModel>>> BuscarTodos()
        {
            var jogos = await _jogoRepositorio.BuscarTodos();

            return Ok(jogos);
        }

        [HttpGet("BuscarPorId/{id}")]
        public async Task<ActionResult<JogoModel>> BuscarPorId(int id)
        {
            var jogo = await _jogoRepositorio.BuscarPorId(id);
            return Ok(jogo);
        }

        [HttpGet("BuscarPorNome/{nome}")]
        public async Task<ActionResult<JogoModel>> BuscarPorNome(string nome)
        {
            var jogos = await _jogoRepositorio.BuscarPorNome(nome);
            return Ok(jogos);
        }

        [HttpGet("BuscarPorPlataforma/{nome}")]
        public async Task<ActionResult<JogoModel>> BuscarPorPlataforma(string nome)
        {
            var jogos = await _jogoRepositorio.BuscarPorPlataforma(nome);
            return Ok(jogos);
        }

        [HttpGet("BuscarPorDesenvolvedora/{nome}")]
        public async Task<ActionResult<JogoModel>> BuscarPorDesenvolvedora(string nome)
        {
            var jogos = await _jogoRepositorio.BuscarPorDesenvolvedora(nome);
            return Ok(jogos);
        }

        [HttpGet("BuscarPorGenero/{nome}")]
        public async Task<ActionResult<JogoModel>> BuscarPorGenero(string nome)
        {
            var jogos = await _jogoRepositorio.BuscarPorGenero(nome);
            return Ok(jogos);
        }

        [HttpPost("Cadastrar")]
        public async Task<ActionResult<JogoModel>> Cadastrar([FromBody] JogoModel jogoModel)
        {
            var jogo = await _jogoRepositorio.Adicionar(jogoModel);

            return Ok(jogo);
        }

        [HttpPut("Atualizar/{id}")]
        public async Task<ActionResult<JogoModel>> Atualizar([FromBody] JogoModel jogoModel, int id)
        {
            jogoModel.Id = id;
            var jogo = await _jogoRepositorio.Atualizar(jogoModel, id);
            return Ok(jogo);
        }

        [HttpDelete("Apagar/{id}")]
        public async Task<ActionResult<JogoModel>> Apagar(int id)
        {
            var apagado = await _jogoRepositorio.Apagar(id);

            return Ok(apagado);
        }
    }
}
