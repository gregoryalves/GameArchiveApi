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
        public async Task<ActionResult<List<UsuarioJogoModel>>> BuscarTodos()
        {
            var usuariosJogos = await _usuarioJogoRepositorio.BuscarTodos();

            return Ok(usuariosJogos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioJogoModel>> BuscarPorId(int id)
        {
            var usuarioJogo = await _usuarioJogoRepositorio.BuscarPorId(id);
            return Ok(usuarioJogo);
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
