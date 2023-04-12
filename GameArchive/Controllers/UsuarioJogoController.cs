using GameArchive.Models;
using GameArchive.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameArchive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioJogoController : ControllerBase
    {
        private readonly IUsuarioJogoRepositorio _usuarioJogoRepositorio;

        public UsuarioJogoController(IUsuarioJogoRepositorio usuarioJogoRepositorio)
        {
            _usuarioJogoRepositorio = usuarioJogoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioJogoModel>>> BuscarTodos()
        {
            var usuariosJogos = await _usuarioJogoRepositorio.BuscarTodos();

            return Ok(usuariosJogos);
        }

        [HttpGet("BuscarTodosPorUsuario/{usuarioId}")]
        public async Task<ActionResult<IEnumerable<UsuarioJogoModel>>> BuscarTodosPorUsuario(int usuarioId)
        {
            var usuariosJogos = await _usuarioJogoRepositorio.BuscarTodosPorUsuario(usuarioId);

            return Ok(usuariosJogos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioJogoModel>> BuscarPorId(int id)
        {
            var usuarioJogo = await _usuarioJogoRepositorio.BuscarPorId(id);
            return Ok(usuarioJogo);
        }

        [HttpGet("BuscarNome/{nome}")]
        public async Task<ActionResult<JogoModel>> BuscarNome([FromQuery] UsuarioJogoModel usuarioJogoModel, string nome)
        {
            var jogos = await _usuarioJogoRepositorio.BuscarPorNome(usuarioJogoModel,nome);
            return Ok(jogos);
        }

        [HttpGet("BuscarPorPlataforma/{nome}")]
        public async Task<ActionResult<JogoModel>> BuscarPorPlataforma([FromQuery] UsuarioJogoModel usuarioJogoModel, string nome)
        {
            var jogos = await _usuarioJogoRepositorio.BuscarPorPlataforma(usuarioJogoModel, nome);
            return Ok(jogos);
        }

        [HttpGet("BuscarPorDesenvolvedora/{nome}")]
        public async Task<ActionResult<JogoModel>> BuscarPorDesenvolvedora([FromQuery] UsuarioJogoModel usuarioJogoModel, string nome)
        {
            var jogos = await _usuarioJogoRepositorio.BuscarPorDesenvolvedora(usuarioJogoModel, nome);
            return Ok(jogos);
        }

        [HttpGet("BuscarPorGenero/{nome}")]
        public async Task<ActionResult<JogoModel>> BuscarPorGenero([FromQuery] UsuarioJogoModel usuarioJogoModel, string nome)
        {
            var jogos = await _usuarioJogoRepositorio.BuscarPorGenero(usuarioJogoModel, nome);
            return Ok(jogos);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioJogoModel>> Cadastrar([FromBody] UsuarioJogoModel usuarioJogoModel)
        {
            var usuarioJogo = await _usuarioJogoRepositorio.Adicionar(usuarioJogoModel);

            return Ok(usuarioJogo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioJogoModel>> Atualizar([FromBody] UsuarioJogoModel usuarioJogoModel, int id)
        {
            usuarioJogoModel.Id = id;
            var usuarioJogo = await _usuarioJogoRepositorio.Atualizar(usuarioJogoModel, id);
            return Ok(usuarioJogo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioJogoModel>> Apagar(int id)
        {
            var apagado = await _usuarioJogoRepositorio.Apagar(id);

            return Ok(apagado);
        }
    }
}
