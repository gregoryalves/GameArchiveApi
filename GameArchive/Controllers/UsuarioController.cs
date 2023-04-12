using GameArchive.Api.DataContracts;
using GameArchive.Models;
using GameArchive.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GameArchive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet("BuscarTodos")]
        public async Task<ActionResult<IEnumerable<UsuarioModel>>> BuscarTodos()
        {
            var usuarios = await _usuarioRepositorio.BuscarTodos();

            return Ok(usuarios);
        }

        [HttpGet("BuscarPorId/{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
        {
            var usuario = await _usuarioRepositorio.BuscarPorId(id);
            return Ok(usuario);
        }

        [HttpPost("Cadastrar")]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
            var usuario = await _usuarioRepositorio.Adicionar(usuarioModel);

            return Ok(usuario);
        }

        [HttpPut("Atualizar/{id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuarioModel, int id)
        {
            usuarioModel.Id = id;
            var usuario = await _usuarioRepositorio.Atualizar(usuarioModel, id);
            return Ok(usuario);
        }

        [HttpDelete("Apagar/{id}")]
        public async Task<ActionResult<UsuarioModel>> Apagar(int id)
        {
            var apagado = await _usuarioRepositorio.Apagar(id);

            return Ok(apagado);
        }

        [HttpGet("Logar")]
        public async Task<ActionResult<int>> Logar([FromQuery] LoginDataContract usuarioLogin)
        {
            var usuarioId = await _usuarioRepositorio.Logar(usuarioLogin);

            return Ok(usuarioId);
        }
    }
}
