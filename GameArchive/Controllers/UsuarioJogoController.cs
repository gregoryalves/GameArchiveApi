using GameArchive.Api.DataContracts;
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

        [HttpGet("BuscarTodos")]
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

        [HttpGet("BuscarPorId/{id}")]
        public async Task<ActionResult<UsuarioJogoModel>> BuscarPorId(int id)
        {
            var usuarioJogo = await _usuarioJogoRepositorio.BuscarPorId(id);
            return Ok(usuarioJogo);
        }

        [HttpGet("BuscarPorNome")]
        public async Task<ActionResult<JogoModel>> BuscarPorNome([FromQuery] UsuarioENomeDataContract usuarioNome)
        {
            var jogos = await _usuarioJogoRepositorio.BuscarPorNome(usuarioNome);
            return Ok(jogos);
        }

        [HttpGet("BuscarPorPlataforma")]
        public async Task<ActionResult<JogoModel>> BuscarPorPlataforma([FromQuery] UsuarioENomeDataContract usuarioNome)
        {
            var jogos = await _usuarioJogoRepositorio.BuscarPorPlataforma(usuarioNome);
            return Ok(jogos);
        }

        [HttpGet("BuscarPorDesenvolvedora")]
        public async Task<ActionResult<JogoModel>> BuscarPorDesenvolvedora([FromQuery] UsuarioENomeDataContract usuarioNome)
        {
            var jogos = await _usuarioJogoRepositorio.BuscarPorDesenvolvedora(usuarioNome);
            return Ok(jogos);
        }

        [HttpGet("BuscarPorGenero")]
        public async Task<ActionResult<JogoModel>> BuscarPorGenero([FromQuery] UsuarioENomeDataContract usuarioNome)
        {
            var jogos = await _usuarioJogoRepositorio.BuscarPorGenero(usuarioNome);
            return Ok(jogos);
        }

        [HttpPost("Cadastrar")]
        public async Task<ActionResult<UsuarioJogoModel>> Cadastrar([FromBody] UsuarioJogoModel usuarioJogoModel)
        {
            var usuarioJogo = await _usuarioJogoRepositorio.Adicionar(usuarioJogoModel);

            return Ok(usuarioJogo);
        }

        [HttpPut("Atualizar/{id}")]
        public async Task<ActionResult<UsuarioJogoModel>> Atualizar([FromBody] UsuarioJogoModel usuarioJogoModel, int id)
        {
            usuarioJogoModel.Id = id;
            var usuarioJogo = await _usuarioJogoRepositorio.Atualizar(usuarioJogoModel, id);
            return Ok(usuarioJogo);
        }

        [HttpDelete("Apagar/{id}")]
        public async Task<ActionResult<UsuarioJogoModel>> Apagar(int id)
        {
            var apagado = await _usuarioJogoRepositorio.Apagar(id);

            return Ok(apagado);
        }
    }
}
